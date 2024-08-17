using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PDD.NET.Domain.Entities;
using PDD.NET.Application.Auth;
using PDD.NET.Application.Auth.Request;
using PDD.NET.Application.Auth.Response;
using MediatR;
using PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;
using PDD.NET.Application.Common.Constants;
using PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;

namespace PDD.NET.Persistence.Services;

public class JwtService : IJwtService
{
    private readonly JwtConfig _jwtConfig;
    private readonly AuthDbContext _context;
    private readonly DbSet<RefreshToken> _entitySet;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IMediator _mediator;

    private const long REFRESH_LIVE_S = 2400;
    private const long ACCESS_LIVE_S = 1200;

    public JwtService(IOptionsMonitor<JwtConfig> jwtConfig, AuthDbContext context, TokenValidationParameters tokenValidationParameters
        , IMediator mediator
        )
    {
        _mediator = mediator;
        _jwtConfig = jwtConfig.CurrentValue;
        _context = context;
        _entitySet = _context.Set<RefreshToken>();
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task<AuthResult> GenerateToken(GetUserAuthResponse user)
    {
        JwtSecurityTokenHandler? jwtTokenHandler = new JwtSecurityTokenHandler();
        //серкретный ключ, который поможет закодировать или закодировать токен
        byte[] key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        var role = user.Roles.Select(x => x.Name).Contains(nameof(UserRole.Admin)) ? nameof(UserRole.Admin) : nameof(UserRole.User);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,role),//можно определ€ть по id роль.
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            //Issuer - издатель, кто создает токен, какой сервис
            //Audience - кто принимает токен
            //Expires-Gets or sets the value of the 'expiration' claim. This value should be in UTC.
            Expires = DateTime.UtcNow.AddSeconds(value: ACCESS_LIVE_S),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //HmacSha256Signature - алгоритм дл€ кодировани€
        };

        // Create token
        SecurityToken? token = jwtTokenHandler.CreateToken(tokenDescriptor);
        // сериализует класс токена в строку
        string jwtToken = jwtTokenHandler.WriteToken(token);

        // Create refresh token
        RefreshToken refreshToken = new RefreshToken()
        {
            JwtId = token.Id,
            IsUsed = false,
            IsRevoked = false,
            Id = user.Id,
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow,
            //ExpiredAt = DateTime.UtcNow.AddMonths(1),
            ExpiredAt = DateTime.UtcNow.AddSeconds(value: REFRESH_LIVE_S),
            Token = GetRandomString() + Guid.NewGuid() //random string - типичный подход.
        };

        RefreshToken? storedToken = await _entitySet.AsNoTracking().FirstOrDefaultAsync(t => t.Id == refreshToken.Id);
        if (storedToken == null)
        {
            await _entitySet.AddAsync(refreshToken);
        }
        else
        {
            storedToken = refreshToken;

            _entitySet.Update(storedToken);
            //_context.Entry(storedToken).State = EntityState.Modified;
        }
        await _context.SaveChangesAsync();

        return new AuthResult()
        {
            Token = jwtToken,
            RefreshToken = refreshToken.Token,
            Success = true,
        };
    }

    //is used to get the user principal from the expired access token.
    public async Task<RefreshTokenResponseDTO?> VerifyRefreshToken(TokenRequestDTO tokenRequest)
    {
        JwtSecurityTokenHandler? jwtTokenHandler = new JwtSecurityTokenHandler();

        try
        {
            ////////////////поиск refresh токена в локальной базе
            RefreshToken? localRefreshToken = await _entitySet.AsNoTracking().FirstOrDefaultAsync(t => t.Token == tokenRequest.RefreshToken);

            if (localRefreshToken == null)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "Token does not found"
                    }
                };
            }
            //пользователь токена в соотв с id
            var userFullResponse = await _mediator.Send(new GetUserFullInfoRequest(localRefreshToken.UserId), CancellationToken.None);

            /* ‘ункци€ ValidateToken() ожидает, что вы передадите основную информацию дл€ проверки токена: идентификатор эмитента токена, аудиторию и ключи подписи эмитента.
             https://auth0.com/blog/how-to-validate-jwt-dotnet/
             */
            ClaimsPrincipal? tokenVerification = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken);

            //REQUIRED. JWT ID. Jti-A unique identifier for the token, which can be used to prevent reuse of the token. These tokens MUST only be used once, unless conditions for reuse were negotiated between the parties; any such negotiation is beyond the scope of this specification https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
            var jti = tokenVerification.Claims.FirstOrDefault(t => t.Type == JwtRegisteredClaimNames.Jti).Value;
            //сравниваем Jti id сохраненного токена и верифицируемого
            if (localRefreshToken.JwtId != jti)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "Token doesn't match"
                    }
                };
            }
            //https://datatracker.ietf.org/doc/html/rfc7519#section-4 
            //The "exp" (expiration time) claim identifies and is defined as the number of seconds 
            long utcExpireDate = long.Parse(tokenVerification.Claims.FirstOrDefault(d => d.Type == JwtRegisteredClaimNames.Exp).Value);

            // UTC to DateTime
            DateTime expireDate = UTCtoDateTime(utcExpireDate);

            Console.WriteLine($"expireDate: {expireDate} - now: {DateTime.Now}");
            //ѕроверка просрочен refresh токен или нет
            if (expireDate > DateTime.Now)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                        "Token not expired"
                    }
                };
            }

            //////////////////Gets the signature algorithm that was used to create the signature.
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                bool result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                if (!result)
                {
                    return null;
                }
            }
            //////////////////
            if (localRefreshToken.IsUsed)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "Token used."
                    }
                };
            }
            ////////////////ќтозван
            if (localRefreshToken.IsRevoked)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "Token revoked."
                    }
                };
            }

            ////////////////
            localRefreshToken.IsUsed = true;
            _context.Entry(localRefreshToken).State = EntityState.Modified;
            //_entitySet.Update(storedToken);
            await _context.SaveChangesAsync();
            _context.Entry(localRefreshToken).State = EntityState.Detached;

            // return token
            return new RefreshTokenResponseDTO()
            {
                Email = userFullResponse.Email,
                Id = localRefreshToken.UserId,
                Success = true,
            };
        }
        catch (Exception e)
        {
            return new RefreshTokenResponseDTO()
            {
                Errors = new List<string>{
                    e.Message
                },
                Success = false
            };
        }
    }

    public async Task<RefreshTokenResponseDTO?> RevokeToken(TokenRequestDTO tokenRequest)
    {
        try
        {
            ////////////////поиск refresh токена в локальной базе
            RefreshToken? localRefreshToken = await _entitySet.AsNoTracking().FirstOrDefaultAsync(t => t.Token == tokenRequest.RefreshToken);

            if (localRefreshToken == null)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "Token does not found"
                    }
                };
            }

            var userFullResponse = await _mediator.Send(new GetUserFullInfoRequest(localRefreshToken.UserId), CancellationToken.None);

            localRefreshToken.IsRevoked = true;
            localRefreshToken.Token = null;
            _context.Entry(localRefreshToken).State = EntityState.Modified;
            //_entitySet.Update(storedToken);
            await _context.SaveChangesAsync();
            _context.Entry(localRefreshToken).State = EntityState.Detached;

            // return token
            return new RefreshTokenResponseDTO()
            {
                Email = userFullResponse.Email,
                Id = localRefreshToken.UserId,
                Success = true,
            };

        }
        catch (Exception e)
        {
            return new RefreshTokenResponseDTO()
            {
                Errors = new List<string>{
                    e.Message
                },
                Success = false
            };
        }
    }

    private DateTime UTCtoDateTime(long unixTimeStamp)
    {
        var datetimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        datetimeVal = datetimeVal.AddSeconds(unixTimeStamp).ToLocalTime();

        return datetimeVal;
    }


    private string GetRandomString()
    {
        Random random = new Random();
        string chars = "ABCDEFGHIJKLMNOPRSTUVYZWX0123456789";
        return new string(Enumerable.Repeat(chars, 35).Select(n => n[new Random().Next(n.Length)]).ToArray());
        /*аналоговнет
                var randomNumber = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                    return Convert.ToBase64String(randomNumber);
                }
        */
    }

    //Validate access token
    public async Task<bool> ValidateTokenTest(TokenRequestDTO tokenRequest)
    {
        //мы это делаем вручную
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, //проверка потребител€ токена
            ValidateIssuer = false,// проверка издател€ токена
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret)),
            ValidateLifetime = true
            //ClockSkew = TimeSpan.Zero
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;

        var principal = tokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
        //var username = jwtSecurityToken.Payload[JwtRegisteredClaimNames.Email].ToString(); ; //this is mapped to the Name claim by default

        RefreshToken? localRefreshToken = await _entitySet.AsNoTracking().FirstOrDefaultAsync(t => t.Token == tokenRequest.RefreshToken);
        var userFullResponse = await _mediator.Send(new GetUserFullInfoRequest(localRefreshToken.UserId), CancellationToken.None);

        if (userFullResponse is null || localRefreshToken is null || localRefreshToken.ExpiredAt <= DateTime.UtcNow)
            throw new SecurityTokenException("Invalid token");
        return true;
    }
}

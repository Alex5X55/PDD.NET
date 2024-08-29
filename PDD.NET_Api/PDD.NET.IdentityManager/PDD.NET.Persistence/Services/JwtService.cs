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
        //серкретный ключ, который поможет закодировать или раскодировать токен
        byte[] key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        var role = user.Roles.Select(x => x.Name).Contains(nameof(UserRole.Admin)) ? nameof(UserRole.Admin) : nameof(UserRole.User);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role,role),//можно определять по id роль.
                new Claim(JwtRegisteredClaimNames.Name, user.Login),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),

            Expires = DateTime.UtcNow.AddMinutes(value: _jwtConfig.LifeTimeAccessMin),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //HmacSha256Signature - алгоритм для кодирования
        };
        // Create token
        SecurityToken? token = jwtTokenHandler.CreateToken(tokenDescriptor);
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
            ExpiredAt = DateTime.UtcNow.AddMinutes(value: _jwtConfig.LifeTimeRefreshMin),
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

            ClaimsPrincipal? tokenVerification = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken);

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
            //Проверка просрочен refresh токен или нет
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
            ////////////////Отозван
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
    }

    //Validate access token
    public async Task<bool> ValidateTokenTest(TokenRequestDTO tokenRequest)
    {
        //мы это делаем вручную
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, //проверка потребителя токена
            ValidateIssuer = false,// проверка издателя токена
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret)),
            ValidateLifetime = true
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;

        var principal = tokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        RefreshToken? localRefreshToken = await _entitySet.AsNoTracking().FirstOrDefaultAsync(t => t.Token == tokenRequest.RefreshToken);
        var userFullResponse = await _mediator.Send(new GetUserFullInfoRequest(localRefreshToken.UserId), CancellationToken.None);

        if (userFullResponse is null || localRefreshToken is null || localRefreshToken.ExpiredAt <= DateTime.UtcNow)
            throw new SecurityTokenException("Invalid token");
        return true;
    }
}

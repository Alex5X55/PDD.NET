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
using PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;
using System.Threading;
using PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;

namespace PDD.NET.Persistence.Services;

public class JwtService : IJwtService
{
    private readonly JwtConfig _jwtConfig;
    private readonly AuthDbContext _context;
    private readonly DbSet<RefreshToken> _entitySet;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IMediator _mediator;
    public JwtService(IOptionsMonitor<JwtConfig> jwtConfig, AuthDbContext context, TokenValidationParameters tokenValidationParameters
        ,IMediator mediator
        )
    {
        _mediator = mediator;
        _jwtConfig = jwtConfig.CurrentValue;
        _context = context;
        _entitySet = _context.Set<RefreshToken>();
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task<AuthResult> GenerateToken(User user, bool isAdmin)
    {

        JwtSecurityTokenHandler? jwtTokenHandler = new JwtSecurityTokenHandler();

        byte[] key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,isAdmin==true ? "Admin" : "User"),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddSeconds(35),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
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
            CreatedAt = DateTime.UtcNow,
            //ExpiredAt = DateTime.UtcNow.AddMonths(1),
            ExpiredAt = DateTime.UtcNow.AddSeconds(5),
            Token = GetRandomString() + Guid.NewGuid()
        };
        //refreshToken.User = user;
        await _entitySet.AddAsync(refreshToken);
        await _context.SaveChangesAsync();



        return new AuthResult()
        {
            Token = jwtToken,
            RefreshToken = refreshToken.Token,
            Success = true,

        };

    }

    public async Task<RefreshTokenResponseDTO> VerifyToken(TokenRequestDTO tokenRequest)
    {
        JwtSecurityTokenHandler? jwtTokenHandler = new JwtSecurityTokenHandler();

        try
        {
            ////////////////
            RefreshToken? storedToken = await _entitySet.FirstOrDefaultAsync(t => t.Token == tokenRequest.RefreshToken);

            if (storedToken == null)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "token does not found"
                    }
                };
            }
            var userFullResponse = await _mediator.Send(new GetUserFullInfoRequest(storedToken.UserId), CancellationToken.None);

            ClaimsPrincipal? tokenVerification = jwtTokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken); //?

            ////////////////
            var jti = tokenVerification.Claims.FirstOrDefault(t => t.Type == JwtRegisteredClaimNames.Jti).Value;

            if (storedToken.JwtId != jti)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "token doesn't match"
                    }
                };
            }

            //////////////////
            long utcExpireDate = long.Parse(tokenVerification.Claims.FirstOrDefault(d => d.Type == JwtRegisteredClaimNames.Exp).Value);

            // UTC to DateTime
            DateTime expireDate = UTCtoDateTime(utcExpireDate);

            Console.WriteLine($"expireDate: {expireDate} - now: {DateTime.Now}");

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

            //////////////////
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                bool result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);//?

                if (!result)
                {
                    return null;
                }
            }
            //////////////////
            if (storedToken.IsUsed)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "token used."
                    }
                };
            }
            ////////////////
            if (storedToken.IsRevoked)
            {
                return new RefreshTokenResponseDTO()
                {
                    Success = false,
                    Errors = new List<string>{
                     "token revoked."
                    }
                };
            }

            ////////////////
            storedToken.IsUsed = true;
            _entitySet.Update(storedToken);
            await _context.SaveChangesAsync();

            // return token
            return new RefreshTokenResponseDTO()
            {
                Email = userFullResponse.Email,
                Id = storedToken.Id,
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
}


using PDD.NET.Application.Auth;
using PDD.NET.Application.Auth.Request;
using PDD.NET.Application.Auth.Response;
using PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Services;

public interface IJwtService
{
    Task<AuthResult> GenerateToken(GetUserAuthResponse user);
    Task<RefreshTokenResponseDTO> VerifyToken(TokenRequestDTO tokenRequest);

}

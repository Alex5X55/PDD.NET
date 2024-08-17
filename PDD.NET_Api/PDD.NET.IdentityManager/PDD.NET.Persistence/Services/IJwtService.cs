
using PDD.NET.Application.Auth;
using PDD.NET.Application.Auth.Request;
using PDD.NET.Application.Auth.Response;
using PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;
using PDD.NET.Domain.Entities;
using System.Security.Claims;

namespace PDD.NET.Persistence.Services;

public interface IJwtService
{
    Task<AuthResult> GenerateToken(GetUserAuthResponse user);
    Task<RefreshTokenResponseDTO?> RefreshToken(TokenRequestDTO tokenRequest);
    Task<RefreshTokenResponseDTO?> RevokeToken(TokenRequestDTO tokenRequest);
    Task<bool> ValidateTokenTest(TokenRequestDTO tokenRequest);
}

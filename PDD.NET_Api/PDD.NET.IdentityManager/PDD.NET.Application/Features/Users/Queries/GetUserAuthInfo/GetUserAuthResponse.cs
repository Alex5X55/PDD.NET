using PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;

namespace PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;

public sealed record GetUserAuthResponse
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public DateTime LastLoginOn { get; set; }

    public UserDetailDTO UserDetail { get; set; }

    public RoleDTO[] Roles { get; set; }
}
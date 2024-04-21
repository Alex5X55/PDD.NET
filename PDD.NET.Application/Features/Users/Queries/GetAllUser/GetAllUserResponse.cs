using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetAllUser;

public sealed record GetAllUserResponse
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

    public DateTime LastLoginOn { get; set; }

    public string PasswordHash { get; set; }

    public UserDetailDTO UserDetail { get; set; }

    public RoleDTO[] Roles { get; set; }
}

public record UserDetailDTO
{
    public string Country { get; set; }
}

public record RoleDTO
{
    public string Name { get; set; }
}
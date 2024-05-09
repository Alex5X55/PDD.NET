namespace PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;

public sealed record GetUserFullInfoResponse
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

    public DateTime LastLoginOn { get; set; }

    public UserDetailDTO UserDetail { get; set; }

    public RoleDTO[] Roles { get; set; }
}

public record UserDetailDTO
{
    public string Country { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }
}

public record RoleDTO
{
    public string Name { get; set; }
}
namespace PDD.NET.Application.Features.Users.Queries.GetAllUser;

public sealed record GetAllUserResponse
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

    public DateTime LastLoginOn { get; set; }

    public string PasswordHash { get; set; }
}
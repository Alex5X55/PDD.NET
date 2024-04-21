namespace PDD.NET.Application.Features.Users.Queries.GetUser;

public sealed record GetUserResponse
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

    public DateTime LastLoginOn { get; set; }

    public string PasswordHash { get; set; }
}
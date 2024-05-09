namespace PDD.NET.Application.Features.Users.Commands.CreateUser;

public sealed record CreateUserResponse
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }
}
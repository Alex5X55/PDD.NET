namespace PDD.NET.Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserResponse
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }
}
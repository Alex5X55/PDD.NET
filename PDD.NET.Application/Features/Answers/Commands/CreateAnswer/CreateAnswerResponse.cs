namespace PDD.NET.Application.Features.Users.Commands.CreateUser;

public sealed record CreateAnswerResponse
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }
}
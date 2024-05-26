namespace PDD.NET.Application.Features.Answers.Commands.CreateAnswer;

public sealed record CreateAnswerResponse
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }
}
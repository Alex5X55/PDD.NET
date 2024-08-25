namespace PDD.NET.Application.Features.AnswerOptions.Commands.CreateAnswerOption;

public sealed record CreateAnswerResponse
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }
}
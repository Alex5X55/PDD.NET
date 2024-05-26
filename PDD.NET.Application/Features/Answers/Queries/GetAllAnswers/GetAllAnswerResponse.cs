namespace PDD.NET.Application.Features.Answers.Queries.GetAllAnswers;

public sealed record GetAllAnswerResponse
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsEnabled { get; set; }
}
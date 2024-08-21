namespace PDD.NET.Application.Features.Answers.Queries.GetAnswer;

public sealed record GetAnswerResponse
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }
}
namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOption;

public sealed record GetAnswerResponse
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }
}
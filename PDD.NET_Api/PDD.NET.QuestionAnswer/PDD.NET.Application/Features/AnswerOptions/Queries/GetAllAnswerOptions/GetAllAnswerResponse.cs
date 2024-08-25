namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAllAnswerOptions;

public sealed record GetAllAnswerResponse
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }
}
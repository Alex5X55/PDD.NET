namespace PDD.NET.Application.Features.Questions.Queries.Common;

public class AnswerOptionsDTO
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }

    public int QuestionId { get; set; }
}
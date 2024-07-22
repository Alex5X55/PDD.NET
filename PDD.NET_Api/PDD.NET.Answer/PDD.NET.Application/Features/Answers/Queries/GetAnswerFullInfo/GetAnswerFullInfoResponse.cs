
namespace PDD.NET.Application.Features.Answers.Queries.GetAnswerFullInfo;

public sealed record GetAnswerFullInfoResponse
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }
    public int QuestionId { get; set; }  // Добавляем свойство QuestionId



}

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOptionFullInfo;

public sealed record GetAnswerFullInfoResponse
{
    public int Id { get; set; }

    public string Text { get; set; }

    public bool IsRight { get; set; }

    public QuestionDTO Question { get; set; }

}

public record QuestionDTO
{
    /// <summary>
    /// Текст вопроса
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Путь к картинке
    /// </summary>
    public string ImageData { get; set; }
}

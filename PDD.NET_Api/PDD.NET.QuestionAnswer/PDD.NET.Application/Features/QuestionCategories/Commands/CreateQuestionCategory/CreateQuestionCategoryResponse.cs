namespace PDD.NET.Application.Features.QuestionCategories.Commands.CreateQuestionCategory;

public sealed record CreateQuestionCategoryResponse
{
    public int Id { get; set; }

    public string Text { get; set; }
}
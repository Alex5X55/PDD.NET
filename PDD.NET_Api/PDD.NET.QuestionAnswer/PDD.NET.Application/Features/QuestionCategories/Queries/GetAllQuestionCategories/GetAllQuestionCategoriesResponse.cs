namespace PDD.NET.Application.Features.QuestionCategories.Queries.GetAllQuestionCategories;

public sealed record GetAllQuestionCategoriesResponse
{
    public int Id { get; set; }
    
    public string Text { get; set; }
}
namespace PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;

public sealed record GetAllQuestionResponse
{
    public int Id { get; set; }
    
    public string Text { get; set; }
    
    public string ImageData { get; set; }
    
    public int CategoryId { get; set; }
    
    public QuestionCategoryDTO Category { get; set; }
    
    public AnswerOptionsDTO[] AnswerOptions { get; set; }
}

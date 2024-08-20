namespace PDD.NET.Application.Features.Questions.Commands.CreateQuestion;

public class CreateQuestionResponse
{
    public int Id { get; set; }
    
    public string Text { get; set; }
    
    public int CategoryId { get; set; }
    
    public string ImageData { get; set; }
}
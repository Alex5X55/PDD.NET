namespace PDD.NET.Application.Features.ExamHistories.Queries.GetExamHistory;

public sealed record GetExamHistoryResponse
{
    public int Id { get; set; }
    
    public bool IsSeccess { get; set; }
    
    public UserDTO UserDTO { get; set; }
}

public record UserDTO
{
    public string Login { get; set; }
}
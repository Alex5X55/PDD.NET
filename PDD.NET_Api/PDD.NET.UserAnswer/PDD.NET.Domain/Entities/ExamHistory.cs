using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities;

public class ExamHistory : BaseEntity
{
    public bool IsSuccess { get; set; }
    
    public User User { get; set; }

    public int UserId { get; set; }
}
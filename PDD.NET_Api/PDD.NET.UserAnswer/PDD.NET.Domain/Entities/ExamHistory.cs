using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities;

public class ExamHistory : BaseEntity
{
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public string Login { get; set; }
    
    public bool IsSuccess { get; set; }
}
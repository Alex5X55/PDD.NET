using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities;

public class UserDetail : BaseEntity
{
    public string Country { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }
}
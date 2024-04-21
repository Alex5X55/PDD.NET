using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities;

public class UserInRole : BaseEntity
{
    public int UserId { get; set; }

    public virtual User User { get; set; }


    public int RoleId { get; set; }

    public virtual Role Role { get; set; }
}
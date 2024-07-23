using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }

    public virtual IEnumerable<UserInRole> UserInRoles { get; set; }
}
using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities;

public class User : BaseEntity
{
    public string Login { get; set; }

    public string Email { get; set; }

    public DateTime? LastLoginOn { get; set; }

    public string? PasswordHash { get; set; }
}
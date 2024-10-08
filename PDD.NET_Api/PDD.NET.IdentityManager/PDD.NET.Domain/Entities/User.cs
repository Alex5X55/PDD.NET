﻿using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities;

public class User : BaseEntity
{
    public string Login { get; set; } //= default!;

    public string Email { get; set; }

    public DateTime? LastLoginOn { get; set; }

    public string? PasswordHash { get; set; }

    public virtual UserDetail UserDetail { get; set; }

    public virtual IEnumerable<UserInRole> UserInRoles { get; set; }
}
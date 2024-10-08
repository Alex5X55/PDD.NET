﻿using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public static class FakeDataFactory
{
    public static IEnumerable<User> Users =>
        new List<User>()
        {
            new User()
            {
                Id = 1,
                Login = "Admin",
                Email = "admin@admin.ru",// password
                LastLoginOn = DateTime.Now,
                PasswordHash = "$2a$11$7YlKi9IEUEWAFw2BaRVBSeykjJ4Aa5lrbBlsjo7JmGM5ulT5uKV5."
            },
            new User()
            {
                Id = 2,
                Login = "TestUser",
                Email = "test-user@mail.ru",
                LastLoginOn = DateTime.Now,
                PasswordHash = "$2a$11$7YlKi9IEUEWAFw2BaRVBSeykjJ4Aa5lrbBlsjo7JmGM5ulT5uKV5."
            }
        };

    public static IEnumerable<UserDetail> UserDetails =>
        new List<UserDetail>()
        {
            new UserDetail()
            {
                Id = 1,
                UserId = 1,
                Country = "RUS",
                Name = "Alex",
                Surname = "Ivanov"
            },
            new UserDetail()
            {
                Id = 2,
                UserId = 2,
                Country = "USA",
                Name = "John",
                Surname = "Smit"
            }
        };

    public static IEnumerable<Role> Roles =>
        new List<Role>()
        {
            new Role() { Id = 1, Name = "Admin" },
            new Role() { Id = 2, Name = "User" }
        };

    public static IEnumerable<UserInRole> UserInRoles =>
        new List<UserInRole>()
        {
            new UserInRole() { UserId = 1, RoleId = 1 },
            new UserInRole() { UserId = 1, RoleId = 2 },
            new UserInRole() { UserId = 2, RoleId = 2 }
        };
}

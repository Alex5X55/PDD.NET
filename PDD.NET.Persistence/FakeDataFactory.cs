using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public static class FakeDataFactory
{
    public static IEnumerable<User> Users => new List<User>()
        {
            new User()
            {
                Id = 1,
                Login = "Admin",
                Email = "admin@admin.ru",
                LastLoginOn = DateTime.Now,
                PasswordHash = "********"
            },
            new User()
            {
                Id = 2,
                Login = "TestUser",
                Email = "test-user@mail.ru",
                LastLoginOn = DateTime.Now,
                PasswordHash = "********"
            }
        };
}

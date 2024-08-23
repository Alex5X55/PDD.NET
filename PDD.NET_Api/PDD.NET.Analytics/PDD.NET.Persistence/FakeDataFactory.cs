using PDD.NET.Domain.Entities;

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
                Email = "admin@admin.ru",
            },
            new User()
            {
                Id = 2,
                Login = "TestUser",
                Email = "test-user@mail.ru",
            }
        };

    public static IEnumerable<AnalyticsData> AnalyticsData =>
        new List<AnalyticsData>()
        {
            new AnalyticsData() { Id = 1, UserId = 1, IsSeccess = true, CreatedOn = new DateTime(2024, 8, 20, 18, 30, 25) },
            new AnalyticsData() { Id = 2, UserId = 1, IsSeccess = false, CreatedOn = new DateTime(2024, 8, 22, 22, 45, 25) },
            new AnalyticsData() { Id = 3, UserId = 2, IsSeccess = false, CreatedOn = new DateTime(2024, 8, 13, 12, 46, 25) },
        };
}

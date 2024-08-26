using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public static class FakeDataFactory
{
    public static IEnumerable<AnalyticsData> AnalyticsData =>
        new List<AnalyticsData>()
        {
            new AnalyticsData() { Login = "Admin", IsSuccess = true, CreatedOn = new DateTime(2024, 8, 20, 18, 30, 25) },
            new AnalyticsData() { Login = "TestUser", IsSuccess = false, CreatedOn = new DateTime(2024, 8, 22, 22, 45, 25) },
        };
}

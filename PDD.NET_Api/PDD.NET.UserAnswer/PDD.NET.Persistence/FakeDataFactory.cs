using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public static class FakeDataFactory
{
    public static IEnumerable<ExamHistory> ExamHistories =>
        new List<ExamHistory>()
        {
            new ExamHistory() { Login = "Admin", IsSuccess = true },
            new ExamHistory() { Login = "TestUser", IsSuccess = false },
        };
}

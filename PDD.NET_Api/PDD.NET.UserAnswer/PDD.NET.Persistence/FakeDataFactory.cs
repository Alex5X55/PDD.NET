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

    public static IEnumerable<ExamHistory> ExamHistories =>
        new List<ExamHistory>()
        {
            new ExamHistory() { UserId = 1, IsSuccess = true },
            new ExamHistory() { UserId = 2, IsSuccess = false },
        };

    public static IEnumerable<AnswerOption> AnswerOptions => new List<AnswerOption>()
    {
        new AnswerOption(){Id = 1, Text = "При наличии болей в области сердца и затрудненного дыхания.", IsRight=false},
        new AnswerOption(){Id = 2 ,Text = "При отсутствии у пострадавшего сознания, независимо от наличия дыхания.", IsRight=false},
        new AnswerOption(){Id = 3 ,Text = "При отсутствии у пострадавшего сознания, дыхания и кровообращения.", IsRight=true},
        new AnswerOption(){Id = 4 ,Text = "Обгон.", IsRight=false},
        new AnswerOption(){Id = 5 ,Text = "Перестроение с дальнейшим опережением.", IsRight=true},
        new AnswerOption(){Id = 6 ,Text = "Объезд.", IsRight=false},
    };

    //public static IEnumerable<UserInAnswerHistory> UserInAnswerHistories => new List<UserInAnswerHistory>()
    //{
    //    new UserInAnswerHistory(){Id = 1 ,AnswerOptionId=1, UserId =1 },
    //};
}

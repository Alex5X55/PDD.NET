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
                PasswordHash = "$2a$11$3uvr8nBwjOK3hfyUtBNMIe6TcBy00pyjuDcpvETK6WwSHRjtlvWQe"
            },
            new User()
            {
                Id = 2,
                Login = "TestUser",
                Email = "test-user@mail.ru",
                LastLoginOn = DateTime.Now,
                PasswordHash = "$2a$11$3uvr8nBwjOK3hfyUtBNMIe6TcBy00pyjuDcpvETK6WwSHRjtlvWQe"
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

    public static IEnumerable<Question> Questions => new List<Question>()
    {
        //src: https://www.pdd24.com/pdd-onlain

        new Question(){Id = 101,CategoryId = 1, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n33_1.jpg", Text = "Какой маневр намеревается выполнить водитель легкового автомобиля?" },
        new Question(){Id = 102,CategoryId = 1, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n5_1.jpg", Text = "Сколько проезжих частей имеет данная дорога?" },
        new Question(){Id = 103,CategoryId = 1, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n13_1.jpg", Text = "Соответствуют ли действия водителя Правилам, если он движется посередине дороги?" },


        new Question(){Id = 401,CategoryId = 4, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n25_5.jpg", Text = "Какой маневр Вам запрещается выполнить при наличии данной линии разметки?" },
        new Question(){Id = 402,CategoryId = 4, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n11_5.jpg", Text = "Эта разметка, нанесенная на полосе движения:" },

        new Question(){Id = 2801,CategoryId = 28, ImageData = "https://storage.yandexcloud.net/pddlife/no_picture.png", Text = "В каких случаях следует начинать сердечно-легочную реанимацию пострадавшего?" },
    };

    public static IEnumerable<QuestionCategory> QuestionCategories => new List<QuestionCategory>()
    {
        new QuestionCategory(){Id = 1 , Text = "1 Общие положения"},
        new QuestionCategory(){Id = 2 , Text = "2 Обязанности водителей"},
        new QuestionCategory(){Id = 3 , Text = "3 Дорожные знаки"},
        new QuestionCategory(){Id = 4 , Text = "4 Дорожная разметка"},

        new QuestionCategory(){Id = 28 , Text = "28 Медицина"}
    };

    public static IEnumerable<ExamHistory> ExamHistories =>
        new List<ExamHistory>()
        {
            new ExamHistory() { UserId = 1, IsSeccess = true },
            new ExamHistory() { UserId = 2, IsSeccess = false },
        };

    public static IEnumerable<AnswerOption> AnswerOptions => new List<AnswerOption>()
    {
        new AnswerOption(){Id = 1 ,QuestionId=2801, Text = "При наличии болей в области сердца и затрудненного дыхания.", IsRight=false},
        new AnswerOption(){Id = 2 ,QuestionId=2801, Text = "При отсутствии у пострадавшего сознания, независимо от наличия дыхания.", IsRight=false},
        new AnswerOption(){Id = 3 ,QuestionId=2801, Text = "При отсутствии у пострадавшего сознания, дыхания и кровообращения.", IsRight=true},
        new AnswerOption(){Id = 4 ,QuestionId=101, Text = "Обгон.", IsRight=false},
        new AnswerOption(){Id = 5 ,QuestionId=101, Text = "Перестроение с дальнейшим опережением.", IsRight=true},
        new AnswerOption(){Id = 6 ,QuestionId=101, Text = "Объезд.", IsRight=false},
    };

    public static IEnumerable<UserInAnswerHistory> UserInAnswerHistories => new List<UserInAnswerHistory>()
    {
        new UserInAnswerHistory(){Id = 1 ,AnswerOptionId=1, UserId =1 },
    };
}

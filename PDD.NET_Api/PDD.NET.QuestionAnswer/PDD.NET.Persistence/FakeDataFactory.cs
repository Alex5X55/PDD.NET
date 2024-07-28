using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public static class FakeDataFactory
{
    public static IEnumerable<QuestionCategory> QuestionCategories => new List<QuestionCategory>()
    {
        new QuestionCategory(){Id = 1 , Text = "1 Общие положения"},
        new QuestionCategory(){Id = 2 , Text = "2 Обязанности водителей"},
        new QuestionCategory(){Id = 3 , Text = "3 Дорожные знаки"},
        new QuestionCategory(){Id = 4 , Text = "4 Дорожная разметка"},
        new QuestionCategory(){Id = 28 , Text = "28 Медицина"}
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

    

    public static IEnumerable<AnswerOption> AnswerOptions => new List<AnswerOption>()
    {
        new AnswerOption(){Id = 1 ,QuestionId=2801, Text = "При наличии болей в области сердца и затрудненного дыхания.", IsRight=false},
        new AnswerOption(){Id = 2 ,QuestionId=2801, Text = "При отсутствии у пострадавшего сознания, независимо от наличия дыхания.", IsRight=false},
        new AnswerOption(){Id = 3 ,QuestionId=2801, Text = "При отсутствии у пострадавшего сознания, дыхания и кровообращения.", IsRight=true},
        new AnswerOption(){Id = 4 ,QuestionId=101, Text = "Обгон.", IsRight=false},
        new AnswerOption(){Id = 5 ,QuestionId=101, Text = "Перестроение с дальнейшим опережением.", IsRight=true},
        new AnswerOption(){Id = 6 ,QuestionId=101, Text = "Объезд.", IsRight=false},
    };
}

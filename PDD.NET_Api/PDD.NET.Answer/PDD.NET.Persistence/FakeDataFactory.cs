using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public static class FakeDataFactory
{
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

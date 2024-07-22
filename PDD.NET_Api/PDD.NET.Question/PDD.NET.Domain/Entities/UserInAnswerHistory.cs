using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities
{
    //TODO Добавить дату время?
    /// <summary>
    /// Сущность истории ответов пользователя на вопросы
    /// </summary>
    public class UserInAnswerHistory : BaseEntity
    {
        public int AnswerOptionId { get; set; }

        public virtual AnswerOption AnswerOption { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}

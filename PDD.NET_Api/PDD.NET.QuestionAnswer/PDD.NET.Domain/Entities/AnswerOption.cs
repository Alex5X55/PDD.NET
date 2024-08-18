using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities
{
    /// <summary>
    /// Сущность ответа на вопрос в билете
    /// </summary>
    public class AnswerOption : BaseEntity
    {
        /// <summary>
        /// Текст ответа
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Признак верного ответа
        /// </summary>
        public bool IsRight { get; set; }

        //public virtual IEnumerable<UserInAnswerHistory> UserAnswersHistories { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

    }
}

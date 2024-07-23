using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities
{
    public class QuestionCategory : BaseEntity
    {
        /// <summary>
        /// Описание категории вопроса
        /// </summary>
        public string Text { get; set; }
        
        public virtual IEnumerable<Question> Questions {  get; set; } 
    }
}

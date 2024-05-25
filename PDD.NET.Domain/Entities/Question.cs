using PDD.NET.Domain.Common;

namespace PDD.NET.Domain.Entities
{
    public class Question : BaseEntity
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Путь к картинке
        /// </summary>
        public string ImageData { get; set; }
        
        /// <summary>
        /// Идентификатор категории вопроса
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Категория вопросов
        /// </summary>
        public virtual QuestionCategory Category { get; set; }
    }
}

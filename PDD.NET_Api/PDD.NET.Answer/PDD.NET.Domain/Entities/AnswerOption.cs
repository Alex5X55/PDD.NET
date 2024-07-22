using PDD.NET.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int QuestionId { get; set; }
    }
}

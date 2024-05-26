using PDD.NET.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.NET.Domain.Entities
{
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

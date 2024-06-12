using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class QuestionCategoryRepository : BaseRepository<QuestionCategory>, IQuestionCategoryRepository
{
    public QuestionCategoryRepository(DatabaseContext context) : base(context)
    {
    }
}
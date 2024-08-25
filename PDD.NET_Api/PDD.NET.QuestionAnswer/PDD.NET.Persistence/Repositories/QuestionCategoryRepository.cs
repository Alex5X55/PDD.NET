using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class QuestionCategoryRepository : BaseRepository<QuestionCategory>, IQuestionCategoryRepository
{
    public QuestionCategoryRepository(DatabaseContext context) : base(context)
    {
    }
    
    public override void Create(QuestionCategory entity)
    {
        var maxId = Context.Set<QuestionCategory>().Select(x=>x.Id).Max();
        entity.Id = maxId + 1;
        base.Create(entity);
    }
}
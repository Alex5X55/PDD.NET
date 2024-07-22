using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
{
    public QuestionRepository(DatabaseContext context) : base(context)
    {
    }

    public override async Task<List<Question>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<Question>().Include(q => q.Category).AsNoTracking().Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
    }

    public override async Task<Question> Get(int id, CancellationToken cancellationToken)
    {
        var question = await Context.Set<Question>().Include(q => q.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);

        return question;
    }
    public async Task<List<Question>> GetQuestionsByCategoryId(int categoryId, CancellationToken cancellationToken)
    {
        var questions = await Context.Set<Question>().Include(q => q.Category).AsNoTracking().Where(x => x.CategoryId == categoryId && !x.IsDeleted).ToListAsync(cancellationToken);

        return questions;
    }
}
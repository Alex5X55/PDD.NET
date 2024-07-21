using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PDD.NET.Persistence.Repositories;

public class ExamHistoryRepository : BaseRepository<ExamHistory>, IExamHistoryRepository
{
    public ExamHistoryRepository(DatabaseContext context) : base(context)
    {
    }
    
    public override async Task<ExamHistory> Get(int id, CancellationToken cancellationToken)
    {
        return await Context.Set<ExamHistory>()
            .Include(eh => eh.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
    }
}
using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class AnswerRepository : BaseRepository<AnswerOption>, IAnswerRepository
{
    public AnswerRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<AnswerOption> GetAnswerFullInfo(int id, CancellationToken cancellationToken)
    {
        return await Context.Set<AnswerOption>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
    }
}

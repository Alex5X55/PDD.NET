using Microsoft.EntityFrameworkCore;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class AnalyticsDataRepository : BaseRepository<AnalyticsData>, IAnalyticsDataRepository
{
    public AnalyticsDataRepository(DatabaseContext context) : base(context)
    {
    }

    public override async Task<List<AnalyticsData>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<AnalyticsData>()
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.CreatedOn)
            .ToListAsync(cancellationToken);
    }
}
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence.Repositories;

public class AnalyticsDataRepository : BaseRepository<AnalyticsData>, IAnalyticsDataRepository
{
    public AnalyticsDataRepository(DatabaseContext context) : base(context)
    {
    }
}
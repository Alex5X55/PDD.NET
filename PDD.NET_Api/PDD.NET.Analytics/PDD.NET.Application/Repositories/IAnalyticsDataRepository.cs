using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Repositories;

public interface IAnalyticsDataRepository : IBaseRepository<AnalyticsData>
{
    public Task<List<AnalyticsData>> GetAnalyticsByLogin(string login, CancellationToken cancellationToken);
}
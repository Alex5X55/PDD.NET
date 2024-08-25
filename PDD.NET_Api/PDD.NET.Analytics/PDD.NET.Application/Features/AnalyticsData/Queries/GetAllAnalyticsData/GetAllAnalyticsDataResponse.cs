
namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;

public sealed record GetAllAnalyticsDataResponse
{
    public DateTime CreatedOn { get; set; }

    public string Login { get; set; }
    
    public bool IsSuccess { get; set; }
}

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;

public sealed record GetAllAnalyticsDataResponse
{
    public int Id { get; set; }

    public DateTime CreatedOn { get; set; }

    public int UserId { get; set; }

    public bool IsSeccess { get; set; }
}
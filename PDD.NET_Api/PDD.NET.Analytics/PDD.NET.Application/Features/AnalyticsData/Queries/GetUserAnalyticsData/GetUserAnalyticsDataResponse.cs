namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetUserAnalyticsData;

public class GetUserAnalyticsDataResponse
{
    public DateTime CreatedOn { get; set; }

    public string Login { get; set; }
    
    public bool IsSuccess { get; set; }
}
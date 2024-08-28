using AutoMapper;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetUserAnalyticsData;

public sealed class GetUserAnalyticsDataMapper : Profile
{
    public GetUserAnalyticsDataMapper()
    {
        CreateMap<Domain.Entities.AnalyticsData, GetUserAnalyticsDataResponse>();
    }
}

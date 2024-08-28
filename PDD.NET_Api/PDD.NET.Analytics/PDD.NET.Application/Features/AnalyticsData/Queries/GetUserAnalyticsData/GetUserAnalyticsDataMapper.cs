using AutoMapper;
using PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetUserAnalyticsData;

public sealed class GetUserAnalyticsDataMapper : Profile
{
    public GetUserAnalyticsDataMapper()
    {
        CreateMap<Domain.Entities.AnalyticsData, GetAllAnalyticsDataResponse>();
    }
}

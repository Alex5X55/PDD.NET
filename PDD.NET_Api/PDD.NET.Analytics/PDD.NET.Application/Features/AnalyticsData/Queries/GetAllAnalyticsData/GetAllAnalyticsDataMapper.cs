using AutoMapper;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;

public sealed class GetAllAnalyticsDataMapper : Profile
{
    public GetAllAnalyticsDataMapper()
    {
        CreateMap<PDD.NET.Domain.Entities.AnalyticsData, GetAllAnalyticsDataResponse>();
    }
}

using MediatR;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;

public sealed record GetAllAnalyticsDataRequest() : IRequest<IEnumerable<GetAllAnalyticsDataResponse>>;
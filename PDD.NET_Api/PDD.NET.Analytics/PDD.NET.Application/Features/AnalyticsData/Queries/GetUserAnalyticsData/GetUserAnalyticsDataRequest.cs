using MediatR;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetUserAnalyticsData;

public sealed record GetUserAnalyticsDataRequest(string Login) : IRequest<IEnumerable<GetUserAnalyticsDataResponse>>;
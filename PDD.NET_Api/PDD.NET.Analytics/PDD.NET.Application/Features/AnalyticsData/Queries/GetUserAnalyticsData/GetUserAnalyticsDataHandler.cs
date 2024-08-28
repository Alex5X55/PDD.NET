using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetUserAnalyticsData;

public sealed class GetUserAnalyticsDataHandler : IRequestHandler<GetUserAnalyticsDataRequest, IEnumerable<GetUserAnalyticsDataResponse>>
{
    private readonly IAnalyticsDataRepository _analyticsDataRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetUserAnalyticsDataHandler(IAnalyticsDataRepository analyticsDataRepository, IMapper mapper, ILogger<GetUserAnalyticsDataHandler> logger)
    {
        _analyticsDataRepository = analyticsDataRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<GetUserAnalyticsDataResponse>> Handle(GetUserAnalyticsDataRequest request, CancellationToken cancellationToken)
    {
        var userAnswerHistories = await _analyticsDataRepository.GetAnalyticsByLogin(request.Login, cancellationToken);

        _logger.LogInformation($"All User Analytics returned");

        return _mapper.Map<IEnumerable<GetUserAnalyticsDataResponse>>(userAnswerHistories);
    }
}
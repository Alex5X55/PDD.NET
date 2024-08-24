using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;

public sealed class GetAllAnalyticsDataHandler : IRequestHandler<GetAllAnalyticsDataRequest, IEnumerable<GetAllAnalyticsDataResponse>>
{
    private readonly IAnalyticsDataRepository _analyticsDataRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAllAnalyticsDataHandler(IAnalyticsDataRepository analyticsDataRepository, IMapper mapper, ILogger<GetAllAnalyticsDataHandler> logger)
    {
        _analyticsDataRepository = analyticsDataRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<GetAllAnalyticsDataResponse>> Handle(GetAllAnalyticsDataRequest request, CancellationToken cancellationToken)
    {
        var userAnswerHistories = await _analyticsDataRepository.GetAll(cancellationToken);
        _logger.LogInformation($"All userAnswerHistories returned");

        return _mapper.Map<IEnumerable<GetAllAnalyticsDataResponse>>(userAnswerHistories);
    }
}
using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.AnalyticsData.Queries.GetAllAnalyticsData;

public sealed class GetAllAnalyticsDataHandler : IRequestHandler<GetAllAnalyticsDataRequest, IEnumerable<GetAllAnalyticsDataResponse>>
{
    private readonly IAnalyticsDataRepository _analyticsDataRepository;
    private readonly IMapper _mapper;

    public GetAllAnalyticsDataHandler(IAnalyticsDataRepository analyticsDataRepository, IMapper mapper)
    {
        _analyticsDataRepository = analyticsDataRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllAnalyticsDataResponse>> Handle(GetAllAnalyticsDataRequest request, CancellationToken cancellationToken)
    {
        var userAnswerHistories = await _analyticsDataRepository.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<GetAllAnalyticsDataResponse>>(userAnswerHistories);
    }
}
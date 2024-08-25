using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.UserInAnswerHistory.Queries.GetAllUserAnswerHistory;

public sealed class GetAllUserAnswerHistoryHandler : IRequestHandler<GetAllUserAnswerHistoryRequest, IEnumerable<GetAllUserAnswerHistoryResponse>>
{
    private readonly IUserAnswerHistoryRepository _userAnswerHistoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAllUserAnswerHistoryHandler(IUserAnswerHistoryRepository userAnswerHistoryRepository, IMapper mapper,ILogger<GetAllUserAnswerHistoryHandler> logger)
    {
        _userAnswerHistoryRepository = userAnswerHistoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<GetAllUserAnswerHistoryResponse>> Handle(GetAllUserAnswerHistoryRequest request, CancellationToken cancellationToken)
    {
        var userAnswerHistories = await _userAnswerHistoryRepository.GetAll(cancellationToken);
        _logger.LogInformation($"All userAnswerHistories returned");

        return _mapper.Map<IEnumerable<GetAllUserAnswerHistoryResponse>>(userAnswerHistories);
    }
}
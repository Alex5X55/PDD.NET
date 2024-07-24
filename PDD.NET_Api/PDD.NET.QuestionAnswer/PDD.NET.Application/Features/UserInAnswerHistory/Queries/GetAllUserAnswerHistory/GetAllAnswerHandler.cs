using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.UserInAnswerHistory.Queries.GetAllUserAnswerHistory;

public sealed class GetAllUserAnswerHistoryHandler : IRequestHandler<GetAllUserAnswerHistoryRequest, IEnumerable<GetAllUserAnswerHistoryResponse>>
{
    private readonly IUserAnswerHistoryRepository _userAnswerHistoryRepository;
    private readonly IMapper _mapper;

    public GetAllUserAnswerHistoryHandler(IUserAnswerHistoryRepository userAnswerHistoryRepository, IMapper mapper)
    {
        _userAnswerHistoryRepository = userAnswerHistoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllUserAnswerHistoryResponse>> Handle(GetAllUserAnswerHistoryRequest request, CancellationToken cancellationToken)
    {
        var userAnswerHistories = await _userAnswerHistoryRepository.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<GetAllUserAnswerHistoryResponse>>(userAnswerHistories);
    }
}
using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Queries.GetExamHistory;

public sealed class GetExamHistoryHandler : IRequestHandler<GetExamHistoryRequest, GetExamHistoryResponse>
{
    private readonly IExamHistoryRepository _examHistoryRepository;
    private readonly IMapper _mapper;

    public GetExamHistoryHandler(IExamHistoryRepository examHistoryRepository, IMapper mapper)
    {
        _examHistoryRepository = examHistoryRepository;
        _mapper = mapper;
    }

    public async Task<GetExamHistoryResponse> Handle(GetExamHistoryRequest request, CancellationToken cancellationToken)
    {
        var examHistory  = _mapper.Map<ExamHistory>(await _examHistoryRepository.Get(request.Id, cancellationToken));
        if (examHistory == null)
        {
            throw new NotFoundException(nameof(ExamHistory), request.Id);
        }

        return _mapper.Map<GetExamHistoryResponse>(examHistory);
    }
}
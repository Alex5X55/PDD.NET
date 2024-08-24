using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Queries.GetExamHistory;

public sealed class GetExamHistoryHandler : IRequestHandler<GetExamHistoryRequest, GetExamHistoryResponse>
{
    private readonly IExamHistoryRepository _examHistoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetExamHistoryHandler(IExamHistoryRepository examHistoryRepository, IMapper mapper,ILogger<GetExamHistoryHandler> logger)
    {
        _examHistoryRepository = examHistoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetExamHistoryResponse> Handle(GetExamHistoryRequest request, CancellationToken cancellationToken)
    {
        var examHistoryOption  = _mapper.Map<ExamHistory>(await _examHistoryRepository.Get(request.Id, cancellationToken));
        if (examHistoryOption == null)
        {
            throw new NotFoundException(nameof(ExamHistory), request.Id);
        }
        _logger.LogInformation($"ExamHistoryOption id {examHistoryOption.Id} entity for user id {examHistoryOption.User.Id} returned");

        return _mapper.Map<GetExamHistoryResponse>(examHistoryOption);
    }
}
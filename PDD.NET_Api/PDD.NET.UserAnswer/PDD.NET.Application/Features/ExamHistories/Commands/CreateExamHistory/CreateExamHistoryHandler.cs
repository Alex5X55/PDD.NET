using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed class CreateExamHistoryHandler : IRequestHandler<CreateExamHistoryRequest, CreateExamHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExamHistoryRepository _examHistoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateExamHistoryHandler(IUnitOfWork unitOfWork, IExamHistoryRepository examHistoryRepository, IMapper mapper,ILogger<CreateExamHistoryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _examHistoryRepository = examHistoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateExamHistoryResponse> Handle(CreateExamHistoryRequest request, CancellationToken cancellationToken)
    {
        // TODO: Добавить проверку на существование пользователя
        
        var examHistoryOption = _mapper.Map<ExamHistory>(request);
        _examHistoryRepository.Create(examHistoryOption);
        
        await _unitOfWork.Save(cancellationToken);
        _logger.LogInformation($"ExamHistoryOption id {examHistoryOption.Id} entity for user id {examHistoryOption.User.Id} created");

        return _mapper.Map<CreateExamHistoryResponse>(examHistoryOption);
    }
}
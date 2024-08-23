using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed class CreateExamHistoryHandler : IRequestHandler<CreateExamHistoryRequest, CreateExamHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExamHistoryRepository _examHistoryRepository;
    private readonly IMapper _mapper;

    public CreateExamHistoryHandler(IUnitOfWork unitOfWork, IExamHistoryRepository examHistoryRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _examHistoryRepository = examHistoryRepository;
        _mapper = mapper;
    }

    public async Task<CreateExamHistoryResponse> Handle(CreateExamHistoryRequest request, CancellationToken cancellationToken)
    {
        // TODO: Добавить проверку на существование пользователя
        
        var examHistoryOption = _mapper.Map<ExamHistory>(request);
        _examHistoryRepository.Create(examHistoryOption);
        
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateExamHistoryResponse>(examHistoryOption);
    }
}
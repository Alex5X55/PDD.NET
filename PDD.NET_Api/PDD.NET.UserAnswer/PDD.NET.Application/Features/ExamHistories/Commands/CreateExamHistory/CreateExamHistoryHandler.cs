using AutoMapper;
using MassTransit;
using MediatR;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Broker;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed class CreateExamHistoryHandler : IRequestHandler<CreateExamHistoryRequest, CreateExamHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExamHistoryRepository _examHistoryRepository;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;


    public CreateExamHistoryHandler(IUnitOfWork unitOfWork, IExamHistoryRepository examHistoryRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _unitOfWork = unitOfWork;
        _examHistoryRepository = examHistoryRepository;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<CreateExamHistoryResponse> Handle(CreateExamHistoryRequest request, CancellationToken cancellationToken)
    {
        // TODO: Добавить проверку на существование пользователя

        ExamHistory examHistoryOption = _mapper.Map<ExamHistory>(request);
        _examHistoryRepository.Create(examHistoryOption);

        UserAnswerSuccsesBrokerRequest brokerRequest = new UserAnswerSuccsesBrokerRequest() { Text = $"test {DateTime.Now}" };
        await _publishEndpoint.Publish(brokerRequest);

        await _unitOfWork.Save(cancellationToken);


        return _mapper.Map<CreateExamHistoryResponse>(examHistoryOption);
    }
}
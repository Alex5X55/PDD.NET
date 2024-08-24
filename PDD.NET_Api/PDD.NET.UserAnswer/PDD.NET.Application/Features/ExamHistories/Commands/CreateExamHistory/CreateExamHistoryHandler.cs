using AutoMapper;
using MassTransit;
using MediatR;
using PDD.NET.Application.Broker;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed class CreateExamHistoryHandler : IRequestHandler<CreateExamHistoryRequest, CreateExamHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExamHistoryRepository _examHistoryRepository;
    private readonly IMapper _mapper;
    private readonly ISendEndpointProvider _sendEndpointProvider;


    public CreateExamHistoryHandler(IUnitOfWork unitOfWork, IExamHistoryRepository examHistoryRepository, IMapper mapper, ISendEndpointProvider sendEndpointProvider)
    {
        _unitOfWork = unitOfWork;
        _examHistoryRepository = examHistoryRepository;
        _mapper = mapper;
        _sendEndpointProvider = sendEndpointProvider;
    }

    public async Task<CreateExamHistoryResponse> Handle(CreateExamHistoryRequest request, CancellationToken cancellationToken)
    {
        // TODO: Добавить проверку на существование пользователя

        ExamHistory examHistoryOption = _mapper.Map<ExamHistory>(request);
        _examHistoryRepository.Create(examHistoryOption);

        MessageDto brokerRequest = new MessageDto() { UserId = examHistoryOption.UserId, IsSuccess = examHistoryOption.IsSuccess, CreatedOn = DateTime.Now };

        // Отправка сообщения в конкретную очередь
        var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:masstransit_event_queue_analitycs"));
        await sendEndpoint.Send(brokerRequest);

        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateExamHistoryResponse>(examHistoryOption);
    }
}
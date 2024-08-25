using AutoMapper;
using MassTransit;
using MediatR;
using PDD.NET.Application.Broker;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed class CreateExamHistoryHandler : IRequestHandler<CreateExamHistoryRequest, CreateExamHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExamHistoryRepository _examHistoryRepository;
    private readonly IMapper _mapper;
    private readonly ISendEndpointProvider _sendEndpointProvider;
    private readonly ILogger _logger;

    public CreateExamHistoryHandler(IUnitOfWork unitOfWork, IExamHistoryRepository examHistoryRepository, IMapper mapper, ISendEndpointProvider sendEndpointProvider, ILogger<CreateExamHistoryHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _examHistoryRepository = examHistoryRepository;
        _mapper = mapper;
        _logger = logger;
        _sendEndpointProvider = sendEndpointProvider;
    }

    public async Task<CreateExamHistoryResponse> Handle(CreateExamHistoryRequest request, CancellationToken cancellationToken)
    {
        ExamHistory examHistory = _mapper.Map<ExamHistory>(request);
        _examHistoryRepository.Create(examHistory);
        
        // TODO
        //MessageDto brokerRequest = new MessageDto() { UserId = examHistory.UserId, IsSuccess = examHistory.IsSuccess, CreatedOn = DateTime.Now };

        // Отправка сообщения в конкретную очередь
        // var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:masstransit_event_queue_analitycs"));
        // await sendEndpoint.Send(brokerRequest);

        await _unitOfWork.Save(cancellationToken);
        _logger.LogInformation($"ExamHistory id {examHistory.Id} entity for user {examHistory.Login} created");

        return _mapper.Map<CreateExamHistoryResponse>(examHistory);
    }
}
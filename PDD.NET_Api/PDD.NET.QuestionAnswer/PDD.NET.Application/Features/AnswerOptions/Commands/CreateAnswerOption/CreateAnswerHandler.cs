using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.CreateAnswerOption;

public sealed class CreateAnswerHandler : IRequestHandler<CreateAnswerRequest, CreateAnswerResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateAnswerHandler(IAnswerRepository answerRepository, IMapper mapper,ILogger<CreateAnswerHandler> logger)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateAnswerResponse> Handle(CreateAnswerRequest request, CancellationToken cancellationToken)
    {
        // TODO: Добавить проверку на существование вопроса

        var answerOption = _mapper.Map<AnswerOption>(request);
        _answerRepository.Create(answerOption);
        _logger.LogInformation($"AnswerOption id {answerOption.Id} entity for question id {answerOption.Question.Id} created");

        return _mapper.Map<CreateAnswerResponse>(answerOption);
    }
}
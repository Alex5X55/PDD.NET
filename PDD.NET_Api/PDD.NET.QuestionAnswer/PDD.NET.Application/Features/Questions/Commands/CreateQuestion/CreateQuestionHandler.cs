using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.CreateQuestion;

public sealed class CreateQuestionHandler : IRequestHandler<CreateQuestionRequest, CreateQuestionResponse>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;


    public CreateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper,ILogger<CreateQuestionHandler> logger)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateQuestionResponse> Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
    {
        var questionOption = _mapper.Map<Question>(request);
        _questionRepository.Create(questionOption);
        _logger.LogInformation($"QuestionOption id {questionOption.Id} entity for question created");

        return _mapper.Map<CreateQuestionResponse>(questionOption);
    }
}
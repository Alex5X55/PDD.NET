using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.DeleteQuestion;

public sealed class DeleteQuestionHandler : IRequestHandler<DeleteQuestionRequest, Unit>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DeleteQuestionHandler(IQuestionRepository questionRepository, IMapper mapper,ILogger<DeleteQuestionHandler> logger)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteQuestionRequest request, CancellationToken cancellationToken)
    {
        var questionOption = await _questionRepository.Get(request.Id, cancellationToken);
        if (questionOption == null)
        {
            throw new NotFoundException(nameof(Question), request.Id);
        }

        questionOption.IsDeleted = true;
        _questionRepository.Update(questionOption);
        _logger.LogInformation($"QuestionOption id {questionOption.Id} entity for question deleted");

        return Unit.Value;
    }
}

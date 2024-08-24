using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.DeleteAnswerOption;

public sealed class DeleteAnswerHandler : IRequestHandler<DeleteAnswerRequest, Unit>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DeleteAnswerHandler(IAnswerRepository answerRepository, IMapper mapper,ILogger<DeleteAnswerHandler> logger)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteAnswerRequest request, CancellationToken cancellationToken)
    {
        var answerOption = await _answerRepository.Get(request.Id, cancellationToken);
        if (answerOption == null)
        {
            throw new NotFoundException(nameof(AnswerOption), request.Id);
        }

        answerOption.IsDeleted = true;
        _answerRepository.Update(answerOption);

        _logger.LogInformation($"AnswerOption id {answerOption.Id} entity for question id {answerOption.Question.Id} deleted");

        return Unit.Value;
    }
}

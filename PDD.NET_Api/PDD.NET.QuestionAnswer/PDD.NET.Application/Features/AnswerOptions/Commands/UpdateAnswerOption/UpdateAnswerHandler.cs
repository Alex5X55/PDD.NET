using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.UpdateAnswerOption;

public sealed class UpdateAnswerHandler : IRequestHandler<UpdateAnswerInternalRequest, Unit>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UpdateAnswerHandler(IAnswerRepository answerRepository, IMapper mapper,ILogger<UpdateAnswerHandler> logger)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateAnswerInternalRequest request, CancellationToken cancellationToken)
    {
        var answerOption = _mapper.Map<AnswerOption>(await _answerRepository.Get(request.Id, cancellationToken));
        if (answerOption == null)
        {
            throw new NotFoundException(nameof(AnswerOption), request.Id);
        }

        answerOption.Text = request.Text;
        answerOption.IsRight = request.IsRight;
        answerOption.QuestionId = request.QuestionId;
        _answerRepository.Update(answerOption);
        
        _logger.LogInformation($"AnswerOption id {answerOption.Id} entity for question id {answerOption.QuestionId} updated");

        return Unit.Value;
    }
}

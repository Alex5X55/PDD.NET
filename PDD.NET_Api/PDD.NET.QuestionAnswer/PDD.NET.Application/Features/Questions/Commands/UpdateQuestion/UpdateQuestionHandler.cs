using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.UpdateQuestion;

public sealed class UpdateQuestionHandler : IRequestHandler<UpdateQuestionInternalRequest, Unit>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UpdateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper, ILogger<UpdateQuestionHandler> logger)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateQuestionInternalRequest request, CancellationToken cancellationToken)
    {
        var questionOption = _mapper.Map<Question>(await _questionRepository.Get(request.Id, cancellationToken));
        if (questionOption == null)
        {
            throw new NotFoundException(nameof(Question), request.Id);
        }

        questionOption.Text = request.Text;
        questionOption.CategoryId = request.CategoryId;
        questionOption.ImageData = request.ImageData;
        _questionRepository.Update(questionOption);
        _logger.LogInformation($"QuestionOption id {questionOption.Id} entity for question updated");

        return Unit.Value;
    }
}
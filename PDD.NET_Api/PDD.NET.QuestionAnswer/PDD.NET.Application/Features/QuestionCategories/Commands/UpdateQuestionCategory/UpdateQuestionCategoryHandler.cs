using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.UpdateQuestionCategory;

public sealed class UpdateQuestionCategoryHandler : IRequestHandler<UpdateQuestionCategoryInternalRequest, Unit>
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UpdateQuestionCategoryHandler(IQuestionCategoryRepository questionCategoryRepository, IMapper mapper,ILogger<UpdateQuestionCategoryHandler> logger)
    {
        _questionCategoryRepository = questionCategoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateQuestionCategoryInternalRequest request, CancellationToken cancellationToken)
    {
        var questionCategory = _mapper.Map<QuestionCategory>(await _questionCategoryRepository.Get(request.Id, cancellationToken));
        if (questionCategory == null)
        {
            throw new NotFoundException(nameof(QuestionCategory), request.Id);
        }

        questionCategory.Text = request.Text;
        _questionCategoryRepository.Update(questionCategory);
        _logger.LogInformation($"QuestionCategory id {questionCategory.Id} entity for question updated");

        return Unit.Value;
    }
}
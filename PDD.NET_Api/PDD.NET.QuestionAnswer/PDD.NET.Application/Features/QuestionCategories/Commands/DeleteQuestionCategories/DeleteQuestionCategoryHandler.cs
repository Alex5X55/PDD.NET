using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.DeleteQuestionCategories;

public sealed class DeleteQuestionCategoryHandler : IRequestHandler<DeleteQuestionCategoryRequest, Unit>
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;


    public DeleteQuestionCategoryHandler(IQuestionCategoryRepository questionCategoryRepository, IMapper mapper,ILogger<DeleteQuestionCategoryHandler> logger)
    {
        _questionCategoryRepository = questionCategoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteQuestionCategoryRequest request, CancellationToken cancellationToken)
    {
        var questionCategory = await _questionCategoryRepository.Get(request.Id, cancellationToken);
        if (questionCategory == null)
        {
            throw new NotFoundException(nameof(QuestionCategory), request.Id);
        }

        questionCategory.IsDeleted = true;
        _questionCategoryRepository.Update(questionCategory);
        _logger.LogInformation($"QuestionCategory id {questionCategory.Id} entity for question deleted");

        return Unit.Value;
    }
}

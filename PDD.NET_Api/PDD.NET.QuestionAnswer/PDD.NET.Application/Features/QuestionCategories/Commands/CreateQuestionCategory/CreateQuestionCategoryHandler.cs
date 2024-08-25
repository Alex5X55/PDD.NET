using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.CreateQuestionCategory;

public sealed class CreateQuestionCategoryHandler : IRequestHandler<CreateQuestionCategoryRequest, CreateQuestionCategoryResponse>
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateQuestionCategoryHandler(IQuestionCategoryRepository questionCategoryRepository, IMapper mapper,ILogger<CreateQuestionCategoryHandler> logger)
    {
        _questionCategoryRepository = questionCategoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateQuestionCategoryResponse> Handle(CreateQuestionCategoryRequest request, CancellationToken cancellationToken)
    {
        var questionCategory = _mapper.Map<QuestionCategory>(request);
        _questionCategoryRepository.Create(questionCategory);
        _logger.LogInformation($"QuestionCategory id {questionCategory.Id} entity for question created");

        return _mapper.Map<CreateQuestionCategoryResponse>(questionCategory);
    }
}
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.QuestionCategories.Queries.GetAllQuestionCategories;

public sealed class GetAllQuestionCategoriesHandler : IRequestHandler<GetAllQuestionCategoriesRequest, IEnumerable<GetAllQuestionCategoriesResponse>>
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAllQuestionCategoriesHandler(IQuestionCategoryRepository questionCategoryRepository, IMapper mapper,ILogger<GetAllQuestionCategoriesHandler> logger)
    {
        _questionCategoryRepository = questionCategoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<GetAllQuestionCategoriesResponse>> Handle(GetAllQuestionCategoriesRequest request, CancellationToken cancellationToken)
    {
        var questionCategories = await _questionCategoryRepository.GetAll(cancellationToken);
        _logger.LogInformation($"All questionCategories returned");

        return _mapper.Map<IEnumerable<GetAllQuestionCategoriesResponse>>(questionCategories);
    }
}
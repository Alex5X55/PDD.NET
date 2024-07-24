using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.QuestionCategories.Queries.GetAllQuestionCategories;

public sealed class GetAllQuestionCategoriesHandler : IRequestHandler<GetAllQuestionCategoriesRequest, IEnumerable<GetAllQuestionCategoriesResponse>>
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllQuestionCategoriesHandler(IQuestionCategoryRepository questionCategoryRepository, IMapper mapper)
    {
        _questionCategoryRepository = questionCategoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllQuestionCategoriesResponse>> Handle(GetAllQuestionCategoriesRequest request, CancellationToken cancellationToken)
    {
        var questionCategories = await _questionCategoryRepository.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<GetAllQuestionCategoriesResponse>>(questionCategories);
    }
}
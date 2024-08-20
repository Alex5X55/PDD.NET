using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.CreateQuestionCategory;

public sealed class CreateQuestionCategoryHandler : IRequestHandler<CreateQuestionCategoryRequest, CreateQuestionCategoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IMapper _mapper;

    public CreateQuestionCategoryHandler(IUnitOfWork unitOfWork, IQuestionCategoryRepository questionCategoryRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _questionCategoryRepository = questionCategoryRepository;
        _mapper = mapper;
    }

    public async Task<CreateQuestionCategoryResponse> Handle(CreateQuestionCategoryRequest request, CancellationToken cancellationToken)
    {
        var questionCategory = _mapper.Map<QuestionCategory>(request);
        _questionCategoryRepository.Create(questionCategory);
        
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateQuestionCategoryResponse>(questionCategory);
    }
}
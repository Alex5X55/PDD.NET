using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Features.QuestionCategories.Commands.DeleteQuestionCategories;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.DeleteQuestionCategory;

public sealed class DeleteQuestionCategoryHandler : IRequestHandler<DeleteQuestionCategoryRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly IMapper _mapper;

    public DeleteQuestionCategoryHandler(IUnitOfWork unitOfWork, IQuestionCategoryRepository questionCategoryRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _questionCategoryRepository = questionCategoryRepository;
        _mapper = mapper;
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

        await _unitOfWork.Save(cancellationToken);

        return Unit.Value;
    }
}

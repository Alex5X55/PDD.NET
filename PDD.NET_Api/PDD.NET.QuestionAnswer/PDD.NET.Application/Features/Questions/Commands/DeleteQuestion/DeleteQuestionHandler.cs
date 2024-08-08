using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.DeleteQuestion;

public sealed class DeleteQuestionHandler : IRequestHandler<DeleteQuestionRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public DeleteQuestionHandler(IUnitOfWork unitOfWork, IQuestionRepository questionRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteQuestionRequest request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.Get(request.Id, cancellationToken);
        if (question == null)
        {
            throw new NotFoundException(nameof(Question), request.Id);
        }

        question.IsDeleted = true;
        _questionRepository.Update(question);
        await _unitOfWork.Save(cancellationToken);

        return Unit.Value;
    }
}

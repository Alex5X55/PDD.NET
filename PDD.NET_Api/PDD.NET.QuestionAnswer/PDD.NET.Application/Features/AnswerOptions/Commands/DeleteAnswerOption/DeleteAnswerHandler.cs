using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Commands.DeleteAnswer;

public sealed class DeleteAnswerHandler : IRequestHandler<DeleteAnswerRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public DeleteAnswerHandler(IUnitOfWork unitOfWork, IAnswerRepository answerRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteAnswerRequest request, CancellationToken cancellationToken)
    {
        var answer = await _answerRepository.Get(request.Id, cancellationToken);
        if (answer == null)
        {
            throw new NotFoundException(nameof(AnswerOption), request.Id);
        }

        answer.IsDeleted = true;
        _answerRepository.Update(answer);
        await _unitOfWork.Save(cancellationToken);

        return Unit.Value;
    }
}

using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.DeleteQuestion;

public sealed class DeleteQuestionHandler : IRequestHandler<DeleteQuestionRequest, Unit>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public DeleteQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
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

        return Unit.Value;
    }
}

using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.UpdateQuestion;

public sealed class UpdateQuestionHandler : IRequestHandler<UpdateQuestionInternalRequest, Unit>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public UpdateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateQuestionInternalRequest request, CancellationToken cancellationToken)
    {
        var question = _mapper.Map<Question>(await _questionRepository.Get(request.Id, cancellationToken));
        if (question == null)
        {
            throw new NotFoundException(nameof(Question), request.Id);
        }

        question.Text = request.Text;
        question.CategoryId = request.CategoryId;
        question.ImageData = request.ImageData;
        _questionRepository.Update(question);
        
        return Unit.Value;
    }
}
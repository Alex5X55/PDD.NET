using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateAnswerHandler : IRequestHandler<UpdateAnswerInternalRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public UpdateAnswerHandler(IUnitOfWork unitOfWork, IAnswerRepository answerRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAnswerInternalRequest request, CancellationToken cancellationToken)
    {
        var answer = _mapper.Map<AnswerOption>(await _answerRepository.Get(request.Id, cancellationToken));
        if (answer == null)
        {
            throw new NotFoundException(nameof(AnswerOption), request.Id);
        }

        answer.Text = request.Text;
        answer.IsRight = request.IsRight;
        _answerRepository.Update(answer);
        await _unitOfWork.Save(cancellationToken);

        return Unit.Value;
    }
}

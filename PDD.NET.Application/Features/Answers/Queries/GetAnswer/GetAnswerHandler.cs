using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Queries.GetAnswer;

public sealed class GetAnswerHandler : IRequestHandler<GetAnswerRequest, GetAnswerResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public GetAnswerHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<GetAnswerResponse> Handle(GetAnswerRequest request, CancellationToken cancellationToken)
    {
        var answer = _mapper.Map<User>(await _answerRepository.Get(request.Id, cancellationToken));
        if (answer == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        return _mapper.Map<GetAnswerResponse>(answer);
    }
}
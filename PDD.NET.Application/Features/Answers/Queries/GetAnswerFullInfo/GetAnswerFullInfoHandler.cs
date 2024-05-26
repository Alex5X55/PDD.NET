using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Queries.GetAnswerFullInfo;

public sealed class GetAnswerFullInfoHandler : IRequestHandler<GetAnswerFullInfoRequest, GetAnswerFullInfoResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public GetAnswerFullInfoHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<GetAnswerFullInfoResponse> Handle(GetAnswerFullInfoRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<AnswerOption>(await _answerRepository.GetAnswerFullInfo(request.Id, cancellationToken));
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        return _mapper.Map<GetAnswerFullInfoResponse>(user);
    }
}
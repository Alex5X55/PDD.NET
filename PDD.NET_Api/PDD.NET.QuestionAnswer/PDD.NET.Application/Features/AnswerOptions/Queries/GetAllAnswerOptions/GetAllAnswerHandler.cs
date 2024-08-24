using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAllAnswerOptions;

public sealed class GetAllAnswerHandler : IRequestHandler<GetAllAnswerRequest, IEnumerable<GetAllAnswerResponse>>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public GetAllAnswerHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllAnswerResponse>> Handle(GetAllAnswerRequest request, CancellationToken cancellationToken)
    {
        var answers = await _answerRepository.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<GetAllAnswerResponse>>(answers);
    }
}
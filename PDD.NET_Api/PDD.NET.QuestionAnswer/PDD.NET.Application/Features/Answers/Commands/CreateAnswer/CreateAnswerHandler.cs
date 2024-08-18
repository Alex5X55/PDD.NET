using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Commands.CreateAnswer;

public sealed class CreateAnswerHandler : IRequestHandler<CreateAnswerRequest, CreateAnswerResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public CreateAnswerHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<CreateAnswerResponse> Handle(CreateAnswerRequest request, CancellationToken cancellationToken)
    {
        var answerOption = _mapper.Map<AnswerOption>(request);
        _answerRepository.Create(answerOption);

        return _mapper.Map<CreateAnswerResponse>(answerOption);
    }
}
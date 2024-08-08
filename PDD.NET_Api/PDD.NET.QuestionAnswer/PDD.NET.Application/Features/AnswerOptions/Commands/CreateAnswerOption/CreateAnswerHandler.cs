using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Commands.CreateAnswer;

public sealed class CreateAnswerHandler : IRequestHandler<CreateAnswerRequest, CreateAnswerResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public CreateAnswerHandler(IUnitOfWork unitOfWork, IAnswerRepository answerRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<CreateAnswerResponse> Handle(CreateAnswerRequest request, CancellationToken cancellationToken)
    {
        var answerOption = _mapper.Map<AnswerOption>(request);
        _answerRepository.Create(answerOption);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateAnswerResponse>(answerOption);
    }
}
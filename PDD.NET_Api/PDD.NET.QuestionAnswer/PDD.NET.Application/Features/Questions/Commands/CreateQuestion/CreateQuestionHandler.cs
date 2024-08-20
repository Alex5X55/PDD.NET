using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.CreateQuestion;

public sealed class CreateQuestionHandler : IRequestHandler<CreateQuestionRequest, CreateQuestionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public CreateQuestionHandler(IUnitOfWork unitOfWork, IQuestionRepository questionRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<CreateQuestionResponse> Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
    {
        var questionOption = _mapper.Map<Question>(request);
        _questionRepository.Create(questionOption);
        
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateQuestionResponse>(questionOption);
    }
}
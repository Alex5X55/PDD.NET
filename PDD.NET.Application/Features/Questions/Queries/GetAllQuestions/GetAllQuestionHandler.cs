using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;

public sealed class GetAllQuestionHandler : IRequestHandler<GetAllQuestionRequest, IEnumerable<GetAllQuestionResponse>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetAllQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllQuestionResponse>> Handle(GetAllQuestionRequest request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<GetAllQuestionResponse>>(questions);
    }
}
using AutoMapper;
using MediatR;
using PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.Questions.Queries.GetExamQuestions;

public sealed class GetExamQuestionsHandler : IRequestHandler<GetExamQuestionsRequest, IEnumerable<GetAllQuestionResponse>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetExamQuestionsHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllQuestionResponse>> Handle(GetExamQuestionsRequest request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetAll(cancellationToken);
        
        // Получаем список из 30 случайных вопросов
        var randomQuestions = questions
            .OrderBy(q => new Random().Next())
            .Take(30);

        return _mapper.Map<IEnumerable<GetAllQuestionResponse>>(randomQuestions);
    }
}
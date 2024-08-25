using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;

public sealed class GetAllQuestionHandler : IRequestHandler<GetAllQuestionRequest, IEnumerable<GetAllQuestionResponse>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAllQuestionHandler(IQuestionRepository questionRepository, IMapper mapper,ILogger<GetAllQuestionHandler> logger)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<GetAllQuestionResponse>> Handle(GetAllQuestionRequest request, CancellationToken cancellationToken)
    {
        var questionOptions = await _questionRepository.GetAll(cancellationToken);
        _logger.LogInformation($"All questionOptions returned");

        return _mapper.Map<IEnumerable<GetAllQuestionResponse>>(questionOptions);
    }
}
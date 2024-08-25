using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionsByCategoryId
{
    public sealed class GetQuestionsByCategoryIdHandler : IRequestHandler<GetQuestionsByCategoryIdRequest, IEnumerable<GetQuestionsByCategoryIdResponse>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetQuestionsByCategoryIdHandler(IQuestionRepository questionRepository, IMapper mapper,ILogger<GetQuestionsByCategoryIdHandler> logger)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<GetQuestionsByCategoryIdResponse>> Handle(GetQuestionsByCategoryIdRequest request, CancellationToken cancellationToken)
        {
            var questionOptions = await _questionRepository.GetQuestionsByCategoryId(request.CategoryId, cancellationToken);
            _logger.LogInformation($"QuestionOptions by CategoryId {request.CategoryId} returned");

            return _mapper.Map<IEnumerable<GetQuestionsByCategoryIdResponse>>(questionOptions);
        }
    }
}

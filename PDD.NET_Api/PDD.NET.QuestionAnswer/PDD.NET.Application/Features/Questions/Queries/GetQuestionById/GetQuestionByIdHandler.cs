using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionById
{
    public sealed class GetQuestionByIdHandler : IRequestHandler<GetQuestionByIdRequest, GetQuestionByIdResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetQuestionByIdHandler(IQuestionRepository questionRepository, IMapper mapper,ILogger<GetQuestionByIdHandler> logger)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetQuestionByIdResponse> Handle(GetQuestionByIdRequest request, CancellationToken cancellationToken)
        {
            var questionOption = await _questionRepository.Get(request.Id, cancellationToken);
            _logger.LogInformation($"QuestionOption id {request.Id} returned");

            return _mapper.Map<GetQuestionByIdResponse>(questionOption);
        }
    }
}

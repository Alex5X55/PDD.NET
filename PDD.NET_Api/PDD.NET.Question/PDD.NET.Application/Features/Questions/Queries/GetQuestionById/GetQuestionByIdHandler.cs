using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionById
{
    public sealed class GetQuestionByIdHandler : IRequestHandler<GetQuestionByIdRequest, GetQuestionByIdResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionByIdHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetQuestionByIdResponse> Handle(GetQuestionByIdRequest request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetQuestionByIdResponse>(question);
        }
    }
}

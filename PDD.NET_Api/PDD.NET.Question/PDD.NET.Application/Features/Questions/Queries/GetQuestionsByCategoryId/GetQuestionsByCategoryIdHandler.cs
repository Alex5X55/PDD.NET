using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionsByCategoryId
{
    public sealed class GetQuestionsByCategoryIdHandler : IRequestHandler<GetQuestionsByCategoryIdRequest, IEnumerable<GetQuestionsByCategoryIdResponse>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionsByCategoryIdHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetQuestionsByCategoryIdResponse>> Handle(GetQuestionsByCategoryIdRequest request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetQuestionsByCategoryId(request.CategoryId, cancellationToken);
            return _mapper.Map<IEnumerable<GetQuestionsByCategoryIdResponse>>(questions);
        }
    }
}

using MediatR;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionsByCategoryId
{
    public sealed record GetQuestionsByCategoryIdRequest(int CategoryId) : IRequest<IEnumerable<GetQuestionsByCategoryIdResponse>>;
}

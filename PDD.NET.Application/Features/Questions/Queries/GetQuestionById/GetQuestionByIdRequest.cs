using MediatR;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestion
{
    public sealed record GetQuestionByIdRequest(int Id) : IRequest<GetQuestionByIdResponse>;
}

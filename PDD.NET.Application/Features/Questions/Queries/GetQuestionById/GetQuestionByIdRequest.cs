using MediatR;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionById
{
    public sealed record GetQuestionByIdRequest(int Id) : IRequest<GetQuestionByIdResponse>;
}

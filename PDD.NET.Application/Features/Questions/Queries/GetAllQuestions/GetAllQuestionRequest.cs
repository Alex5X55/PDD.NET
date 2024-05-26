using MediatR;

namespace PDD.NET.Application.Features.Questions.Queries.GetAllQuestion;

public sealed record GetAllQuestionRequest() : IRequest<IEnumerable<GetAllQuestionResponse>>;

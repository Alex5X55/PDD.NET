using MediatR;

namespace PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;

public sealed record GetAllQuestionRequest() : IRequest<IEnumerable<GetAllQuestionResponse>>;

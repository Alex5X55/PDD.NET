using MediatR;

namespace PDD.NET.Application.Features.Answers.Queries.GetAllAnswers;

public sealed record GetAllAnswerRequest() : IRequest<IEnumerable<GetAllAnswerResponse>>;
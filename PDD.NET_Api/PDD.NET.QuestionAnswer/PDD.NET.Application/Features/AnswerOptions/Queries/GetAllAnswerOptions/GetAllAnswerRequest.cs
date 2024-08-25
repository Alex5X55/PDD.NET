using MediatR;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAllAnswerOptions;

public sealed record GetAllAnswerRequest() : IRequest<IEnumerable<GetAllAnswerResponse>>;
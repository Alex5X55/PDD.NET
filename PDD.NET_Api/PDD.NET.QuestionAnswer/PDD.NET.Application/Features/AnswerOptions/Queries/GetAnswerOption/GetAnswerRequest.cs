using MediatR;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOption;

public sealed record GetAnswerRequest(int Id) : IRequest<GetAnswerResponse>;
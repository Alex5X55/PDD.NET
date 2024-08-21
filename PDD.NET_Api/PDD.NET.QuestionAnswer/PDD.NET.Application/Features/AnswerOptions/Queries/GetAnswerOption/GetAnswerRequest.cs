using MediatR;

namespace PDD.NET.Application.Features.Answers.Queries.GetAnswer;

public sealed record GetAnswerRequest(int Id) : IRequest<GetAnswerResponse>;
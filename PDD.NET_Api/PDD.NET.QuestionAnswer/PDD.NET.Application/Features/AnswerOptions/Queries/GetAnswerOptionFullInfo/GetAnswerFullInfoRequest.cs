using MediatR;

namespace PDD.NET.Application.Features.Answers.Queries.GetAnswerFullInfo;

public sealed record GetAnswerFullInfoRequest(int Id) : IRequest<GetAnswerFullInfoResponse>;
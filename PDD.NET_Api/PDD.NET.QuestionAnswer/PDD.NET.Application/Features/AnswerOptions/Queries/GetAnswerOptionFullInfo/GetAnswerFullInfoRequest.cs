using MediatR;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOptionFullInfo;

public sealed record GetAnswerFullInfoRequest(int Id) : IRequest<GetAnswerFullInfoResponse>;
using MediatR;

namespace PDD.NET.Application.Features.UserInAnswerHistory.Queries.GetAllUserAnswerHistory;

public sealed record GetAllUserAnswerHistoryRequest() : IRequest<IEnumerable<GetAllUserAnswerHistoryResponse>>;
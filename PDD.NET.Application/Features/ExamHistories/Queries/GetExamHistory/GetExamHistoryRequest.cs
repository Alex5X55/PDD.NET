using MediatR;

namespace PDD.NET.Application.Features.ExamHistories.Queries.GetExamHistory;

public sealed record GetExamHistoryRequest(int Id) : IRequest<GetExamHistoryResponse>;
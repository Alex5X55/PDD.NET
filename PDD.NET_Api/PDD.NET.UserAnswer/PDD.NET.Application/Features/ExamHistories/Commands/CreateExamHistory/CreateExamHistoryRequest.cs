using MediatR;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed record CreateExamHistoryRequest(int UserId, bool IsSeccess) : IRequest<CreateExamHistoryResponse>;
using MediatR;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed record CreateExamHistoryRequest(int UserId, bool IsSuccess) : IRequest<CreateExamHistoryResponse>;
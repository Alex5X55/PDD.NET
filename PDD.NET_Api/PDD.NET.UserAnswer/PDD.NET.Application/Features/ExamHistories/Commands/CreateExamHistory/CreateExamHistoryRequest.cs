using MediatR;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed record CreateExamHistoryRequest(string Login, bool IsSuccess) : IRequest<CreateExamHistoryResponse>;
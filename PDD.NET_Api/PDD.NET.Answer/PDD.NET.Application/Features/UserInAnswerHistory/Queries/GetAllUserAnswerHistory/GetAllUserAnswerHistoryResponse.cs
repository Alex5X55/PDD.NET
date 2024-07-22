using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.UserInAnswerHistory.Queries.GetAllUserAnswerHistory;
//TODO User Name/Id -Answer Text?
public sealed record GetAllUserAnswerHistoryResponse
{
    public int AnswerOptionId { get; set; }

    public int UserId { get; set; }
}
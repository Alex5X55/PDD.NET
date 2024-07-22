using AutoMapper;

namespace PDD.NET.Application.Features.UserInAnswerHistory.Queries.GetAllUserAnswerHistory;

public sealed class GetAllUserAnswerHistoryMapper : Profile
{
    public GetAllUserAnswerHistoryMapper()
    {
        CreateMap<Domain.Entities.UserInAnswerHistory, GetAllUserAnswerHistoryResponse>();
    }
}

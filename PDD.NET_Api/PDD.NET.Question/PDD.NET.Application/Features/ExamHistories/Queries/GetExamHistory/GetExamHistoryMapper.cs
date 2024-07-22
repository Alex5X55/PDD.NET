using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Queries.GetExamHistory;

public sealed class GetExamHistoryMapper : Profile
{
    public GetExamHistoryMapper()
    {
        CreateMap<ExamHistory, GetExamHistoryResponse>()
            .ForMember(dest => dest.UserDTO,
                opt => opt.MapFrom(src => src.User));
        
        CreateMap<User, UserDTO>();
    }
}
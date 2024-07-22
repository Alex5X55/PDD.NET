using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Queries.GetAnswerFullInfo;

public sealed class GetAnswerFullInfoMapper : Profile
{
    public GetAnswerFullInfoMapper()
    {
        CreateMap<AnswerOption, GetAnswerFullInfoResponse>()
            .ForMember(dest => dest.QuestionId, opt => opt.MapFrom(src => src.QuestionId));

        // Если вам больше не нужна маппинг для Question, вы можете удалить следующую строку
        // CreateMap<Question, QuestionDTO>();
    }
}

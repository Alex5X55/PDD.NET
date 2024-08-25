using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOptionFullInfo;

public sealed class GetAnswerFullInfoMapper : Profile
{
    public GetAnswerFullInfoMapper()
    {
        CreateMap<AnswerOption, GetAnswerFullInfoResponse>()
            .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question));

        CreateMap<Question, QuestionDTO>();
    }
}
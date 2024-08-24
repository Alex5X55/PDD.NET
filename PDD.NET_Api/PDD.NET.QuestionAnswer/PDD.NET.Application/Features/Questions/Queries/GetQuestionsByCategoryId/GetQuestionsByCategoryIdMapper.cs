using AutoMapper;
using PDD.NET.Application.Features.Questions.Queries.Common;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionsByCategoryId
{
    public sealed class GetQuestionsByCategoryIdMapper : Profile
    {
        public GetQuestionsByCategoryIdMapper()
        {
            CreateMap<Question, GetQuestionsByCategoryIdResponse>()
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.AnswerOptions,
                opt => opt.MapFrom(src => src.AnswerOptions));

            CreateMap<QuestionCategory, QuestionCategoryDTO>();
            CreateMap<AnswerOption, AnswerOptionsDTO>();
        }
    }
}

using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestionsByCategoryId
{
    public sealed class GetQuestionsByCategoryIdMapper : Profile
    {
        public GetQuestionsByCategoryIdMapper()
        {
            CreateMap<Question, GetQuestionsByCategoryIdResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<QuestionCategory, QuestionCategoryDTO>();
        }
    }
}

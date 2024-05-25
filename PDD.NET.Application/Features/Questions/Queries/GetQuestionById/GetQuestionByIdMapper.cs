using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Queries.GetQuestion
{
    public sealed class GetQuestionByIdMapper : Profile
    {
        public GetQuestionByIdMapper()
        {
            CreateMap<Question, GetQuestionByIdResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<QuestionCategory, QuestionCategoryDTO>();
        }
    }
}

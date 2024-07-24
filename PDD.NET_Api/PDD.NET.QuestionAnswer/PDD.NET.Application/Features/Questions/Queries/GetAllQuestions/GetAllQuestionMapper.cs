using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;

public sealed class GetAllQuestionMapper : Profile
{
    public GetAllQuestionMapper()
    {
        CreateMap<Question, GetAllQuestionResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

        CreateMap<QuestionCategory, QuestionCategoryDTO>();
    }
}

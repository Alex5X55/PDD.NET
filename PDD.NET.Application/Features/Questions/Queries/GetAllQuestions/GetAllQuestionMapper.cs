using AutoMapper;
using PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Queries.GetAllQuestion;

public sealed class GetAllQuestionMapper : Profile
{
    public GetAllQuestionMapper()
    {
        CreateMap<Question, GetAllQuestionResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

        CreateMap<QuestionCategory, QuestionCategoryDTO>();
    }
}

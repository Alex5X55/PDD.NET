using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Queries.GetAllQuestionCategories;

public sealed class GetAllQuestionCategoriesMapper : Profile
{
    public GetAllQuestionCategoriesMapper()
    {
        CreateMap<QuestionCategory, GetAllQuestionCategoriesResponse>();
    }
}
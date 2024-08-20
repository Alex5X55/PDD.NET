using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.CreateQuestionCategory;

public sealed class CreateQuestionCategoryMapper : Profile
{
    public CreateQuestionCategoryMapper()
    {
        CreateMap<CreateQuestionCategoryRequest, QuestionCategory>();
        CreateMap<QuestionCategory, CreateQuestionCategoryResponse>();
    }
}
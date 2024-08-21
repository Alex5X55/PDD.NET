using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.UpdateQuestionCategory;

public sealed class UpdateQuestionCategoryMapper : Profile
{
    public UpdateQuestionCategoryMapper()
    {
        CreateMap<UpdateQuestionCategoryInternalRequest, QuestionCategory>();
    }
}
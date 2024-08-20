using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.DeleteQuestionCategories;

public sealed class DeleteQuestionCategoryMapper : Profile
{
    public DeleteQuestionCategoryMapper()
    {
        CreateMap<DeleteQuestionCategoryRequest, QuestionCategory>();
    }
}
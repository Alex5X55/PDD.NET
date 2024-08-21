using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.UpdateQuestion;

public sealed class UpdateQuestionMapper : Profile
{
    public UpdateQuestionMapper()
    {
        CreateMap<UpdateQuestionInternalRequest, Question>();
    }
}
using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Commands.UpdateAnswer;

public sealed class UpdateAnswerMapper : Profile
{
    public UpdateAnswerMapper()
    {
        CreateMap<UpdateAnswerInternalRequest, AnswerOption>();
    }
}
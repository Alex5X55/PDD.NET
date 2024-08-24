using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.UpdateAnswerOption;

public sealed class UpdateAnswerMapper : Profile
{
    public UpdateAnswerMapper()
    {
        CreateMap<UpdateAnswerInternalRequest, AnswerOption>();
    }
}
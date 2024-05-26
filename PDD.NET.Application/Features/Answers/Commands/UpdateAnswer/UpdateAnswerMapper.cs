using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateAnswerMapper : Profile
{
    public UpdateAnswerMapper()
    {
        CreateMap<UpdateAnswerInternalRequest, AnswerOption>();
    }
}
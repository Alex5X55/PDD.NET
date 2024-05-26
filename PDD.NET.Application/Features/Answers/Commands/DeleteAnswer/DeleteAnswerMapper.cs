using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Commands.DeleteUser;

public sealed class DeleteAnswerMapper : Profile
{
    public DeleteAnswerMapper()
    {
        CreateMap<DeleteAnswerRequest, AnswerOption>();
    }
}
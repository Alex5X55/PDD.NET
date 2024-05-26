using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Commands.CreateUser;

public sealed class CreateAnswerMapper : Profile
{
    public CreateAnswerMapper()
    {
        CreateMap<CreateAnswerRequest, AnswerOption>().ReverseMap();
    }
}
using AutoMapper;
using PDD.NET.Application.Features.Users.Commands.CreateUser;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Commands.CreateAnswer;

public sealed class CreateAnswerMapper : Profile
{
    public CreateAnswerMapper()
    {
        //CreateMap<CreateAnswerResponse, AnswerOption>().ReverseMap();

        CreateMap<CreateAnswerRequest, AnswerOption>();
        CreateMap<AnswerOption, CreateAnswerResponse>();
    }
}
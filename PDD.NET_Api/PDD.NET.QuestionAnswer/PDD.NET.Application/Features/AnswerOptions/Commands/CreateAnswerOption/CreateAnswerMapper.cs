using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.CreateAnswerOption;

public sealed class CreateAnswerMapper : Profile
{
    public CreateAnswerMapper()
    {
        CreateMap<CreateAnswerRequest, AnswerOption>();
        CreateMap<AnswerOption, CreateAnswerResponse>();
    }
}
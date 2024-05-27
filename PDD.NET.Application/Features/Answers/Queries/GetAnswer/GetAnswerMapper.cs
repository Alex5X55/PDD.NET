using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Queries.GetAnswer;

public sealed class GetAnswerMapper : Profile
{
    public GetAnswerMapper()
    {
        CreateMap<AnswerOption, GetAnswerResponse>();
    }
}
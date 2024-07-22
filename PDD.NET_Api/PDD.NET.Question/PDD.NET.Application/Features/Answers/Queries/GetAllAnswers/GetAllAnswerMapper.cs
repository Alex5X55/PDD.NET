using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Queries.GetAllAnswers;

public sealed class GetAllAnswerMapper : Profile
{
    public GetAllAnswerMapper()
    {
        CreateMap<AnswerOption, GetAllAnswerResponse>();
    }
}

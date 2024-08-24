using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOption;

public sealed class GetAnswerMapper : Profile
{
    public GetAnswerMapper()
    {
        CreateMap<AnswerOption, GetAnswerResponse>();
    }
}
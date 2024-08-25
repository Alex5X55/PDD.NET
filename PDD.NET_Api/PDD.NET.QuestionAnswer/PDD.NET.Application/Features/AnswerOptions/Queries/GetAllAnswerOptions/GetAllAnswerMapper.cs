using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAllAnswerOptions;

public sealed class GetAllAnswerMapper : Profile
{
    public GetAllAnswerMapper()
    {
        CreateMap<AnswerOption, GetAllAnswerResponse>();
    }
}

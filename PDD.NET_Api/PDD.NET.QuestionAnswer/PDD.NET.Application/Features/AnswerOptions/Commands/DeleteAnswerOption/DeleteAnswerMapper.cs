using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.DeleteAnswerOption;

public sealed class DeleteAnswerMapper : Profile
{
    public DeleteAnswerMapper()
    {
        CreateMap<DeleteAnswerRequest, AnswerOption>();
    }
}
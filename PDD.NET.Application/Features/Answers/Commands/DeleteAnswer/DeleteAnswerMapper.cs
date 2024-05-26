using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Commands.DeleteAnswer;

public sealed class DeleteAnswerMapper : Profile
{
    public DeleteAnswerMapper()
    {
        CreateMap<DeleteAnswerRequest, AnswerOption>();
    }
}
using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.DeleteQuestion;

public sealed class DeleteQuestionMapper : Profile
{
    public DeleteQuestionMapper()
    {
        CreateMap<DeleteQuestionRequest, Question>();
    }
}
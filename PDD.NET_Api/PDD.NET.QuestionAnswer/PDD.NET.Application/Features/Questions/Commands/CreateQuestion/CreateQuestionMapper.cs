using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Questions.Commands.CreateQuestion;

public sealed class CreateQuestionMapper : Profile
{
    public CreateQuestionMapper()
    {
        CreateMap<CreateQuestionRequest, Question>();
        CreateMap<Question, CreateQuestionResponse>();
    }
}
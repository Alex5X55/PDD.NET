using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.ExamHistories.Commands.CreateExamHistory;

public sealed class CreateExamHistoryMapper : Profile
{
    public CreateExamHistoryMapper()
    {
        CreateMap<CreateExamHistoryRequest, ExamHistory>();
        CreateMap<ExamHistory, CreateExamHistoryResponse>();
    }
}
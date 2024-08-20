﻿using AutoMapper;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Answers.Commands.CreateAnswer;

public sealed class CreateAnswerMapper : Profile
{
    public CreateAnswerMapper()
    {
        CreateMap<CreateAnswerRequest, AnswerOption>();
        CreateMap<AnswerOption, CreateAnswerResponse>();
    }
}
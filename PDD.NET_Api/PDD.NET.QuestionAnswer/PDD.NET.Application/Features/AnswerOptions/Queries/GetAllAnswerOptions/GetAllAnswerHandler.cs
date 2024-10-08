﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAllAnswerOptions;

public sealed class GetAllAnswerHandler : IRequestHandler<GetAllAnswerRequest, IEnumerable<GetAllAnswerResponse>>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAllAnswerHandler(IAnswerRepository answerRepository, IMapper mapper,ILogger<GetAllAnswerHandler> logger)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<GetAllAnswerResponse>> Handle(GetAllAnswerRequest request, CancellationToken cancellationToken)
    {
        var answers = await _answerRepository.GetAll(cancellationToken);
        _logger.LogInformation($"All answerOptions returned");

        return _mapper.Map<IEnumerable<GetAllAnswerResponse>>(answers);
    }
}
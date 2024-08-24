using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOption;

public sealed class GetAnswerHandler : IRequestHandler<GetAnswerRequest, GetAnswerResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAnswerHandler(IAnswerRepository answerRepository, IMapper mapper,ILogger<GetAnswerHandler> logger)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetAnswerResponse> Handle(GetAnswerRequest request, CancellationToken cancellationToken)
    {
        var answerOption = _mapper.Map<AnswerOption>(await _answerRepository.Get(request.Id, cancellationToken));
        if (answerOption == null)
        {
            throw new NotFoundException(nameof(AnswerOption), request.Id);
        }
        _logger.LogInformation($"AnswerOption id {request.Id} returned");

        return _mapper.Map<GetAnswerResponse>(answerOption);
    }
}
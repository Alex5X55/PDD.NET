using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.AnswerOptions.Queries.GetAnswerOptionFullInfo;

public sealed class GetAnswerFullInfoHandler : IRequestHandler<GetAnswerFullInfoRequest, GetAnswerFullInfoResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAnswerFullInfoHandler(IAnswerRepository answerRepository, IMapper mapper, ILogger<GetAnswerFullInfoHandler> logger)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetAnswerFullInfoResponse> Handle(GetAnswerFullInfoRequest request, CancellationToken cancellationToken)
    {
        var answerOption = _mapper.Map<AnswerOption>(await _answerRepository.GetAnswerFullInfo(request.Id, cancellationToken));
        if (answerOption == null)
        {
            throw new NotFoundException(nameof(AnswerOption), request.Id);
        }
        _logger.LogInformation($"Full info answerOption id {request.Id} returned");

        return _mapper.Map<GetAnswerFullInfoResponse>(answerOption);
    }
}
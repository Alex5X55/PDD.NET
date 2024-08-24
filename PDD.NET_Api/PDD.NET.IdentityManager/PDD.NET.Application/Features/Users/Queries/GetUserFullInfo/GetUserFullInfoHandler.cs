using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;

public sealed class GetUserFullInfoHandler : IRequestHandler<GetUserFullInfoRequest, GetUserFullInfoResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetUserFullInfoHandler> _logger;

    public GetUserFullInfoHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetUserFullInfoHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetUserFullInfoResponse> Handle(GetUserFullInfoRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(await _userRepository.GetUserFullInfo(request.Id, cancellationToken));
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        _logger.LogInformation($"Full info user {request.Id} returned");
        return _mapper.Map<GetUserFullInfoResponse>(user);
    }
}
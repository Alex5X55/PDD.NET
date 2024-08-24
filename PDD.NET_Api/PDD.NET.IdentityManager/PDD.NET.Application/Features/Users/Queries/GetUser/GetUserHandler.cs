using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetUser;

public sealed class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetUserHandler(IUserRepository userRepository, IMapper mapper,ILogger<GetUserHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(await _userRepository.Get(request.Id, cancellationToken));
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        _logger.LogInformation($"User id {request.Id} returned");
        return _mapper.Map<GetUserResponse>(user);
    }
}
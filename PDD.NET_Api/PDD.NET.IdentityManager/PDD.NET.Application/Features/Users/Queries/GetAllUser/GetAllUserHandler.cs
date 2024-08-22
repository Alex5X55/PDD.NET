using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Features.Users.Queries.GetUser;
using PDD.NET.Application.Repositories;

namespace PDD.NET.Application.Features.Users.Queries.GetAllUser;

public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, IEnumerable<GetAllUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllUserHandler> _logger;

    public GetAllUserHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetAllUserHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll(cancellationToken);
        _logger.LogInformation($"All users returned by API request");
        return _mapper.Map<IEnumerable<GetAllUserResponse>>(users);
    }
}
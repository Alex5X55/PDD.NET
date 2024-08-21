using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetUserAuthInfo;

public sealed class GetUserAuthHandler : IRequestHandler<GetUserAuthRequest, GetUserAuthResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserAuthHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserAuthResponse> Handle(GetUserAuthRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(await _userRepository.GetUserAuthInfo(request.email, cancellationToken));
        if (user == null)
        {
            throw new NotFoundException(nameof(User));
        }

        return _mapper.Map<GetUserAuthResponse>(user);
    }
}
using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.Users.Queries.GetUserFullInfo;

public sealed class GetUserFullInfoHandler : IRequestHandler<GetUserFullInfoRequest, GetUserFullInfoResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserFullInfoHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserFullInfoResponse> Handle(GetUserFullInfoRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(await _userRepository.GetUserFullInfo(request.Id, cancellationToken));
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        return _mapper.Map<GetUserFullInfoResponse>(user);
    }
}
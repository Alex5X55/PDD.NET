using AutoMapper;
using MediatR;
using PDD.NET.Application.Repositories;

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
        var user = await _userRepository.GetUserFullInfo(request.id, cancellationToken);
        return _mapper.Map<GetUserFullInfoResponse>(user);
    }
}
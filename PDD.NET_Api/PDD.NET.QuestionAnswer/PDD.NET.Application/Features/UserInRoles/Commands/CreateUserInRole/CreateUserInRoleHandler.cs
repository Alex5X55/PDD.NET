using AutoMapper;
using MediatR;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.UserInRoles.Commands.CreateUserInRole;

public sealed class CreateUserInRoleHandler : IRequestHandler<CreateUserInRoleRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserInRoleRepository _userInRoleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public CreateUserInRoleHandler(
        IUnitOfWork unitOfWork,
        IUserInRoleRepository userInRoleRepository,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userInRoleRepository = userInRoleRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateUserInRoleRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.UserId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var role = await _roleRepository.Get(request.RoleId, cancellationToken);
        if (role == null)
        {
            throw new NotFoundException(nameof(Role), request.RoleId);
        }

        var existsUserInRole = await _userInRoleRepository.GetUserInRole(request.UserId, request.RoleId, cancellationToken);
        if (existsUserInRole != null)
        {
            throw new BadRequestException($"User with id: {request.UserId} already in role with id: {request.RoleId}");
        }

        var userInRole = _mapper.Map<UserInRole>(request);
        _userInRoleRepository.Create(userInRole);
        await _unitOfWork.Save(cancellationToken);

        return Unit.Value;
    }
}

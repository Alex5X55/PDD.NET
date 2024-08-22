using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PDD.NET.Application.Common.Exceptions;
using PDD.NET.Application.Repositories;
using PDD.NET.Domain.Entities;

namespace PDD.NET.Application.Features.UserInRoles.Commands.DeleteUserInRole;

public sealed class DeleteUserInRoleHandler : IRequestHandler<DeleteUserInRoleRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserInRoleRepository _userInRoleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DeleteUserInRoleHandler(
        IUnitOfWork unitOfWork,
        IUserInRoleRepository userInRoleRepository,
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IMapper mapper,
        ILogger<DeleteUserInRoleHandler> logger
    )
    {
        _unitOfWork = unitOfWork;
        _userInRoleRepository = userInRoleRepository;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteUserInRoleRequest request, CancellationToken cancellationToken)
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

        var userInRole = await _userInRoleRepository.GetUserInRole(request.UserId, request.RoleId, cancellationToken);
        if (userInRole == null)
        {
            throw new NotFoundException($"Not found roleId: {request.RoleId} for userId: {request.UserId}");
        }

        _userInRoleRepository.DeleteUserInRole(userInRole);
        await _unitOfWork.Save(cancellationToken);

        _logger.LogInformation($"UserInRole {userInRole.Role.Name} entity for {userInRole.Id} deleted by API request");

        return Unit.Value;
    }
}

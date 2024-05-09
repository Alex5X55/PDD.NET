using MediatR;

namespace PDD.NET.Application.Features.UserInRoles.Commands.CreateUserInRole;

public sealed record CreateUserInRoleRequest(int UserId, int RoleId) : IRequest<Unit>;
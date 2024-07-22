using MediatR;

namespace PDD.NET.Application.Features.UserInRoles.Commands.DeleteUserInRole;

public sealed record DeleteUserInRoleRequest(int UserId, int RoleId) : IRequest<Unit>;
using MediatR;

namespace PDD.NET.Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserRequest(string Login, string Email) : IRequest<Unit>;

public sealed record UpdateUserInternalRequest(int Id, string Login, string Email) : IRequest<Unit>;
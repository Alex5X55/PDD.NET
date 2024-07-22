using MediatR;

namespace PDD.NET.Application.Features.Users.Commands.DeleteUser;

public sealed record DeleteUserRequest(int Id) : IRequest<Unit>;
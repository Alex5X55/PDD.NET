using MediatR;

namespace PDD.NET.Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserRequest(int Id, string Login, string Email) : IRequest<UpdateUserResponse>;
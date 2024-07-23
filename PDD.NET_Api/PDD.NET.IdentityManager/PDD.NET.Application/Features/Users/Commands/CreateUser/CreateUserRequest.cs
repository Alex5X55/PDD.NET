using MediatR;

namespace PDD.NET.Application.Features.Users.Commands.CreateUser;

public sealed record CreateUserRequest(string Login, string Email) : IRequest<CreateUserResponse>;
using MediatR;

namespace PDD.NET.Application.Features.Users.Commands.DeleteUser;

public sealed record DeleteAnswerRequest(int Id) : IRequest<Unit>;
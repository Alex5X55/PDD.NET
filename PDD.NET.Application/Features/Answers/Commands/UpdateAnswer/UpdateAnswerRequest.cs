using MediatR;

namespace PDD.NET.Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateAnswerRequest(string Text, bool IsRight) : IRequest<Unit>;

public sealed record UpdateAnswerInternalRequest(int Id, string Text, bool IsRight) : IRequest<Unit>;
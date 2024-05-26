using MediatR;

namespace PDD.NET.Application.Features.Users.Commands.CreateUser;

public sealed record CreateAnswerRequest(string Text, bool IsRight) : IRequest<CreateAnswerResponse>;
using MediatR;

namespace PDD.NET.Application.Features.Answers.Commands.CreateAnswer;

public sealed record CreateAnswerRequest(string Text, bool IsRight) : IRequest<CreateAnswerResponse>;
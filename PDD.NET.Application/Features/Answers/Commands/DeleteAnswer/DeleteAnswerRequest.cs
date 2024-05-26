using MediatR;

namespace PDD.NET.Application.Features.Answers.Commands.DeleteAnswer;

public sealed record DeleteAnswerRequest(int Id) : IRequest<Unit>;
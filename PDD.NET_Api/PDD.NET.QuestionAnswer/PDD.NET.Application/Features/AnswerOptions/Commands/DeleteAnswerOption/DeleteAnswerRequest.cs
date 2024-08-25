using MediatR;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.DeleteAnswerOption;

public sealed record DeleteAnswerRequest(int Id) : IRequest<Unit>;
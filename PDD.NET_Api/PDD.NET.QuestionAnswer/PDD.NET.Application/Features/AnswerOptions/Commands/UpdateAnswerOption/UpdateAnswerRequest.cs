using MediatR;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.UpdateAnswerOption;

public sealed record UpdateAnswerRequest(string Text, bool IsRight, int QuestionId) : IRequest<Unit>;

public sealed record UpdateAnswerInternalRequest(int Id, string Text, bool IsRight, int QuestionId) : IRequest<Unit>;
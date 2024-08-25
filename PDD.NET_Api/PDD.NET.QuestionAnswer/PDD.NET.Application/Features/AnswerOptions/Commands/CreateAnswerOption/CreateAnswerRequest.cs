using MediatR;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.CreateAnswerOption;

public sealed record CreateAnswerRequest(int Id, string Text, int QuestionId, bool IsRight) : IRequest<CreateAnswerResponse>;
using MediatR;

namespace PDD.NET.Application.Features.Answers.Commands.CreateAnswer;

public sealed record CreateAnswerRequest(int Id, string Text, int QuestionId, bool IsRight) : IRequest<CreateAnswerResponse>;
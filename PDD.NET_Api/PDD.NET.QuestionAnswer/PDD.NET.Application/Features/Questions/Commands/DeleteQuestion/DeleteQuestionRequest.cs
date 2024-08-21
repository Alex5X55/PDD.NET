using MediatR;

namespace PDD.NET.Application.Features.Questions.Commands.DeleteQuestion;

public sealed record DeleteQuestionRequest(int Id) : IRequest<Unit>;
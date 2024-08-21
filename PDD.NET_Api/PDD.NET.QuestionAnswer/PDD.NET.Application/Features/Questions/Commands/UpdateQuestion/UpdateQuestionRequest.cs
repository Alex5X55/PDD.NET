using MediatR;

namespace PDD.NET.Application.Features.Questions.Commands.UpdateQuestion;

public sealed record UpdateQuestionRequest(int CategoryId, string Text, string ImageData) : IRequest<Unit>;

public sealed record UpdateQuestionInternalRequest(int Id, int CategoryId, string Text, string ImageData) : IRequest<Unit>;
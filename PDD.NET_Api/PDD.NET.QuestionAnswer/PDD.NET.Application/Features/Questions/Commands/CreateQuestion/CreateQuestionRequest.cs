using MediatR;

namespace PDD.NET.Application.Features.Questions.Commands.CreateQuestion;

public sealed record CreateQuestionRequest(int CategoryId, string Text, string ImageData) : IRequest<CreateQuestionResponse>;
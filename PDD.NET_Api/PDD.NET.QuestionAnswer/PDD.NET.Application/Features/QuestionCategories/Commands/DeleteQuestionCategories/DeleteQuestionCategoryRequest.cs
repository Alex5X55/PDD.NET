using MediatR;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.DeleteQuestionCategories;

public sealed record DeleteQuestionCategoryRequest(int Id) : IRequest<Unit>;
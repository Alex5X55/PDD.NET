using MediatR;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.UpdateQuestionCategory;

public sealed record UpdateQuestionCategoryRequest(string Text) : IRequest<Unit>;

public sealed record UpdateQuestionCategoryInternalRequest(int Id, string Text) : IRequest<Unit>;
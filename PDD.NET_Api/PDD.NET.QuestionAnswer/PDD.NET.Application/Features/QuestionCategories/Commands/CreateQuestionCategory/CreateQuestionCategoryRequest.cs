using MediatR;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.CreateQuestionCategory;

public sealed record CreateQuestionCategoryRequest(string Text) : IRequest<CreateQuestionCategoryResponse>;
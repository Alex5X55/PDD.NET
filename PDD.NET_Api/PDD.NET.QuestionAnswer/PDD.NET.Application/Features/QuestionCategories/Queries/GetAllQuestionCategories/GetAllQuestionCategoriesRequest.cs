using MediatR;

namespace PDD.NET.Application.Features.QuestionCategories.Queries.GetAllQuestionCategories;

public sealed record GetAllQuestionCategoriesRequest() : IRequest<IEnumerable<GetAllQuestionCategoriesResponse>>;
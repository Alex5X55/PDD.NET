using MediatR;
using PDD.NET.Application.Features.Questions.Queries.GetAllQuestions;

namespace PDD.NET.Application.Features.Questions.Queries.GetExamQuestions;

public sealed record GetExamQuestionsRequest() : IRequest<IEnumerable<GetAllQuestionResponse>>;

using FluentValidation;
using PDD.NET.Application.Common.Constants;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.CreateQuestionCategory;

public sealed class CreateQuestionCategoryValidator : AbstractValidator<CreateQuestionCategoryRequest>
{
    public CreateQuestionCategoryValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Question category cannot be empty")
            .MaximumLength(ProjectConstants.MAX_TEXT_LENGHT).WithMessage($"Question category must be less than {ProjectConstants.MAX_TEXT_LENGHT} characters");
    }
}
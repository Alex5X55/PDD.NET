using FluentValidation;
using PDD.NET.Application.Common.Constants;

namespace PDD.NET.Application.Features.QuestionCategories.Commands.UpdateQuestionCategory;

public sealed class UpdateQuestionCategoryValidator : AbstractValidator<UpdateQuestionCategoryInternalRequest>
{
    public UpdateQuestionCategoryValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("QuestionCategory cannot be empty")
            .MaximumLength(ProjectConstants.MAX_TEXT_LENGHT).WithMessage($"QuestionCategory must be less than {ProjectConstants.MAX_TEXT_LENGHT} characters");
    }
}
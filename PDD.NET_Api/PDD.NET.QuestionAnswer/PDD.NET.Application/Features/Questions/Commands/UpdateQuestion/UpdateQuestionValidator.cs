using FluentValidation;
using PDD.NET.Application.Common.Constants;

namespace PDD.NET.Application.Features.Questions.Commands.UpdateQuestion;

public sealed class UpdateQuestionValidator : AbstractValidator<UpdateQuestionInternalRequest>
{
    public UpdateQuestionValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Question cannot be empty")
            .MaximumLength(ProjectConstants.MAX_TEXT_LENGHT).WithMessage($"Question must be less than {ProjectConstants.MAX_TEXT_LENGHT} characters");
    }
}
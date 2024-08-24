using FluentValidation;
using PDD.NET.Application.Common.Constants;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.UpdateAnswerOption;

public sealed class UpdateAnswerValidator : AbstractValidator<UpdateAnswerInternalRequest>
{
    public UpdateAnswerValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Answer cannot be empty")
            .MaximumLength(ProjectConstants.MAX_TEXT_LENGHT).WithMessage($"Answer must be less than {ProjectConstants.MAX_TEXT_LENGHT} characters");
    }
}
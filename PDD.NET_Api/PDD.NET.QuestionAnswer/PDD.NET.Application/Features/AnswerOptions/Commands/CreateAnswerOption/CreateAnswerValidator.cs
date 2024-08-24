using FluentValidation;
using PDD.NET.Application.Common.Constants;

namespace PDD.NET.Application.Features.AnswerOptions.Commands.CreateAnswerOption;

public sealed class CreateAnswerValidator : AbstractValidator<CreateAnswerRequest>
{
    public CreateAnswerValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Answer cannot be empty")
            .MaximumLength(ProjectConstants.MAX_TEXT_LENGHT).WithMessage($"Answer must be less than {ProjectConstants.MAX_TEXT_LENGHT} characters");
    }
}
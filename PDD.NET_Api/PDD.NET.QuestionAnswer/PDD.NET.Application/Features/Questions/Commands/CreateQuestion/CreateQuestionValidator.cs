using FluentValidation;
using PDD.NET.Application.Common.Constants;

namespace PDD.NET.Application.Features.Questions.Commands.CreateQuestion;

public sealed class CreateQuestionValidator : AbstractValidator<CreateQuestionRequest>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Question cannot be empty")
            .MaximumLength(ProjectConstants.MAX_TEXT_LENGHT).WithMessage($"Question must be less than {ProjectConstants.MAX_TEXT_LENGHT} characters");
    }
}
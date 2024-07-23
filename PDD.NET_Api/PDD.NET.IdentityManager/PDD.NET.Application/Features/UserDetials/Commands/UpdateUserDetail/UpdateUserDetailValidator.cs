using FluentValidation;

namespace PDD.NET.Application.Features.UserDetials.Commands.UpdateUserDetail;

public sealed class UpdateUserDetailValidator : AbstractValidator<UpdateUserDetailInternalRequest>
{
    public UpdateUserDetailValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required")
            .MinimumLength(3).WithMessage("Surname must be at least 3 characters long")
            .MaximumLength(50).WithMessage("Surname must be less than 50 characters");

        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required")
            .MinimumLength(3).WithMessage("Country must be at least 3 characters long")
            .MaximumLength(50).WithMessage("Country must be less than 50 characters");
    }
}
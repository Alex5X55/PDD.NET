using FluentValidation;

namespace PDD.NET.Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Login).NotEmpty().WithMessage("Login cannot be empty")
            .MinimumLength(3).WithMessage("Login must be at least 3 characters long")
            .MaximumLength(50).WithMessage("Login must be less than 50 characters");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .MaximumLength(50).WithMessage("Email must be less than 50 characters")
            .EmailAddress().WithMessage("Email is not a valid email address");
    }
}
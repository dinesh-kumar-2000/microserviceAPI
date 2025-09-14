using Ecommerce.IdentityService.Application.DTOs.User;
using FluentValidation;

namespace Ecommerce.IdentityService.Application.Validators.User;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User name is required.")
            .Length(3, 32).WithMessage("User name must be between 3 and 32 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\!\?\*\.@#\$%&]").WithMessage("Password must contain at least one special character (!?*.@#$%&)");

        // Optional validations if used in your DTO
        RuleFor(x => x.FirstName)
            .MaximumLength(128).WithMessage("First name can't be longer than 128 characters.");
        RuleFor(x => x.LastName)
            .MaximumLength(128).WithMessage("Last name can't be longer than 128 characters.");
        RuleFor(x => x.PhoneNumber)
            .MaximumLength(32).WithMessage("Phone number can't be longer than 32 characters.");
    }
}
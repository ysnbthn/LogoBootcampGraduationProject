using BootcampProject.Core.DTOs;
using FluentValidation;

namespace BootcampProject.Core.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email is not valid");
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password is required");
        }
    }
}

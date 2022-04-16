using BootcampProject.Core.DTOs;
using FluentValidation;

namespace BootcampProject.Core.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email is not valid");
            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password is required")
                .Matches("(?=^.{6,20}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$")
                .WithMessage("Password must be contains atleast 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-20 characters");
            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required")
                .MinimumLength(2)
                .WithMessage("Name must be at least 2 characters")
                .MaximumLength(20)
                .WithMessage("Name must be less than 20 characters");
            RuleFor(u => u.Surname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Surname is required")
                .MinimumLength(2)
                .WithMessage("Surname must be at least 2 characters")
                .MaximumLength(20)
                .WithMessage("Surname must be less than 20 characters");
            RuleFor(u => u.TCNo)
                .NotNull()
                .NotEmpty()
                .WithMessage("TCNo is required")
                .Matches(@"^[1-9][0-9]{10}$")
                .WithMessage("TCNo is not valid");
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Phone number is required")
                .Length(11)
                .WithMessage("Phone number must be 11 characters")
                .Matches("^(05)([0-9]{2})\\s?([0-9]{3})\\s?([0-9]{2})\\s?([0-9]{2})$")
                .WithMessage("Phone number is not valid");
            RuleFor(u => u.CarPlateNumber)
                .Matches("^(0[1-9]|[1-7][0-9]|8[01])(([A-Z])(\\d{4,5})|([A-Z]{2})(\\d{3,4})|([A-Z]{3})(\\d{2,3}))$")
                .WithMessage("Plate Number is not valid");
        }
    }
}

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
                .WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email is not valid");
            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password is required")
                .MaximumLength(20)
                .WithMessage("Password must be less than 20 characters")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters")
                ;
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(2)
                .WithMessage("Name must be at least 2 characters")
                .MaximumLength(20).WithMessage("Name must be less than 20 characters");
            RuleFor(u => u.Surname)
                .NotEmpty()
                .WithMessage("Surname is required")
                .MinimumLength(2)
                .WithMessage("Surname must be at least 2 characters")
                .MaximumLength(20).WithMessage("Surname must be less than 20 characters");
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required")
                .Length(11)
                .WithMessage("Phone number must be 11 characters")
                .Matches("/ ^(05)([0 - 9]{2})\\s ? ([0 - 9]{ 3})\\s ? ([0 - 9]{ 2})\\s ? ([0 - 9]{ 2})$/")
                .WithMessage("Phone number is not valid");
            
        }
    }
}

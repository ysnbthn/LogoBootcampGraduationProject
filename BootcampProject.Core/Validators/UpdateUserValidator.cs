using BootcampProject.Core.DTOs;
using FluentValidation;

namespace BootcampProject.Core.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            //RuleFor(u => u.Email)
            //    .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
            //    .WithMessage("New Email is not valid")
            //    .When(x => x.Email != "" || x.Email != null);
            //RuleFor(u => u.Password)
            //    .Matches("(?=^.{6,20}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$")
            //    .WithMessage("New password must be contains atleast 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-20 characters")
            //    .When(x => x.Password != "" || x.Password != null);
            RuleFor(u => u.Name)
                .MinimumLength(2)
                .WithMessage("New name must be at least 2 characters")
                .MaximumLength(20)
                .WithMessage("New name must be less than 20 characters")
                .When(x => x.Name != "" || x.Name != null);
            RuleFor(u => u.Surname)
                .MinimumLength(2)
                .WithMessage("New surname must be at least 2 characters")
                .MaximumLength(20)
                .WithMessage("New surname must be less than 20 characters")
                .When(x => x.Surname != "" || x.Surname != null);
            RuleFor(u => u.TCNo)
                .Matches(@"^[1-9][0-9]{10}$")
                .WithMessage("New TCNo is not valid")
                .When(x => x.TCNo != "" || x.TCNo != null);
            RuleFor(u => u.PhoneNumber)
                .Length(11)
                .WithMessage("New phone number must be 11 characters")
                .Matches("^(05)([0-9]{2})\\s?([0-9]{3})\\s?([0-9]{2})\\s?([0-9]{2})$")
                .WithMessage("New phone number is not valid")
                .When(x => x.PhoneNumber != "" || x.PhoneNumber != null);
            RuleFor(u => u.CarPlateNumber)
                .Matches("^(0[1-9]|[1-7][0-9]|8[01])(([A-Z])(\\d{4,5})|([A-Z]{2})(\\d{3,4})|([A-Z]{3})(\\d{2,3}))$")
                .WithMessage("New plate Number is not valid")
                .When(x => x.CarPlateNumber != "" || x.CarPlateNumber != null);
        }
    }
}

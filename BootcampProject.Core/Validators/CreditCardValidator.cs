using BootcampProject.Domain.MongoDbEntities;
using FluentValidation;

namespace BootcampProject.Core.Validators
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x=>x.CardNumber)
                .NotNull()
                .NotEmpty()
                .Matches("^5[1-5][0-9]{0,14}|^(222[1-9]|2[3-6]\\d{2}|27[0-1]\\d|2720)[0-9]{0,12}")
                .WithMessage("Card number is not valid");
            RuleFor(x => x.CVV)
                .NotEmpty()
                .NotNull()
                .Matches("^[0-9]{3}$")
                .WithMessage("CVV must be 3 digits long");
            RuleFor(x => x.Expiry)
                .NotEmpty()
                .NotNull()
                .Matches("^(0[1-9]|1[0-2])\\/([0-9]{4})$")
                .WithMessage("Expiry date is not valid");
            RuleFor(x=>x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please enter the name on the credit card");
        }
    }
}

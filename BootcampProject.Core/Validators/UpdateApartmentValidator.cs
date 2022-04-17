using BootcampProject.Core.DTOs.ApartmentDtos;
using FluentValidation;

namespace BootcampProject.Core.Validators
{
    public class UpdateApartmentValidator : AbstractValidator<UpdateApartmentDto>
    {
        public UpdateApartmentValidator()
        {
            RuleFor(a => a.Floor)
               .ExclusiveBetween(-1, 100)
               .WithMessage("Floor must be between 0 and 100")
               .When(x=> x.Floor == 0);
            RuleFor(a => a.ApartmentNumber)
                .ExclusiveBetween(0, 400)
                .WithMessage("Room number must be between 0 and 400")
                .When(x => x.Floor == 0);
            RuleFor(a => a.FlatTypeId)
                .GreaterThan(0)
                .WithMessage("Apartment type is required")
                .When(x => x.Floor == 0);
            RuleFor(a => a.BlockId)
                .GreaterThan(0)
                .WithMessage("Apartment block is required")
                .When(x => x.Floor == 0);
            RuleFor(a => a.OwnerOrHirerId)
                .GreaterThan(0)
                .WithMessage("Owner is required")
                .When(x => x.Floor == 0);
        }
    }
}

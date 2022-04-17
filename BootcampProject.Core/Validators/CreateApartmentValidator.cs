using BootcampProject.Core.DTOs.ApartmentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.Validators
{
    public class CreateApartmentValidator : AbstractValidator<CreateApartmentDto>
    {
        public CreateApartmentValidator()
        {
            RuleFor(a => a.Floor)
                .NotNull()
                .NotEmpty()
                .WithMessage("Floor number is required")
                .ExclusiveBetween(-1, 100)
                .WithMessage("Floor must be between 0 and 100");
            RuleFor(a => a.ApartmentNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Apartment number is required")
                .ExclusiveBetween(0, 400)
                .WithMessage("Room number must be between 0 and 400");
            RuleFor(a => a.FlatTypeId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Apartment type is required");
            RuleFor(a => a.BlockId)
                .GreaterThan(0)
                .NotNull()
                .NotEmpty()
                .WithMessage("Apartment block is required");
        }
    }
}

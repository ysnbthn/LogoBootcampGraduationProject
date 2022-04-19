using BootcampProject.Core.DTOs.InvoiceDtos;
using FluentValidation;
using System;

namespace BootcampProject.Core.Validators
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceDto>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(i => i.InvoiceTypeId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Invoice Type is required");
            RuleFor(i => i.PaymentDue)
                .NotEmpty()
                .NotNull()
                .WithMessage("Invoice Date is required")                
                .GreaterThan(i=> DateTime.Now)
                .WithMessage("Invoice Due date must be greater than today");
            RuleFor(i => i.Amount)
                .GreaterThan(0)
                .WithMessage("Payment Amount must be greater than 0");
        }
    }
}

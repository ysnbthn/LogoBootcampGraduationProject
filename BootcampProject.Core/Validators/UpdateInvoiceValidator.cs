using BootcampProject.Core.DTOs.InvoiceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.Validators
{
    public class UpdateInvoiceValidator : AbstractValidator<UpdateInvoiceDto>
    {
        public UpdateInvoiceValidator()
        {
            RuleFor(i => i.InvoiceTypeId)
                .GreaterThan(0)
                .WithMessage("Invoice Type is required")
                .When(i => i.InvoiceTypeId == 0);
            RuleFor(i => i.PaymentDue)
                .GreaterThan(i => DateTime.Now)
                .WithMessage("Invoice Due date must be greater than today")
                .When(i=>i.PaymentDue.ToShortDateString() != "1.01.0001");
            RuleFor(i => i.Amount)
                .Matches("^[0-9]+(\\,[0-9]{1,2})$")
                .WithMessage("Please enter a Decimal number with maximum 2 decimal places.")
                .When(i => i.Amount != null || i.Amount != "");
        }
    }
}

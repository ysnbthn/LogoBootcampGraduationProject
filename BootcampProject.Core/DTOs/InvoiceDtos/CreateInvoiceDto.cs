using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.InvoiceDtos
{
    public class CreateInvoiceDto
    {
        public int InvoiceTypeId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
        public DateTime PaymentDue { get; set; }
    }
}

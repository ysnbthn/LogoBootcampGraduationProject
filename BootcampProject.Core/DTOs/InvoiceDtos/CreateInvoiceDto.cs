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

        public string Amount { get; set; }
        public DateTime PaymentDue { get; set; }
    }
}

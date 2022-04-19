using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.InvoiceDtos
{
    public class UpdateInvoiceDto
    {
        public int Id { get; set; }
        public int InvoiceTypeId { get; set; }
        public string Amount { get; set; }
        public DateTime PaymentDue { get; set; }
    }
}

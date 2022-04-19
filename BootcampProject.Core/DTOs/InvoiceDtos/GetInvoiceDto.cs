using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.InvoiceDtos
{
    public class GetInvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceTypeName { get; set; }

        public decimal Amount { get; set; }
        public bool Paid { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime PaymentDue { get; set; }
    }
}

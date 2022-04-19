using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.InvoiceDtos
{
    public class PaginatedInvoicesDto
    {
        public List<GetInvoiceDto> Invoices { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}

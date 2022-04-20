using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public int InvoiceTypeId { get; set; }
        public InvoiceType InvoiceType { get; set; }

        public decimal Amount { get; set; }
        public DateTime PaymentDue { get; set; }

        public IList<ApplicationUserInvoice> ApplicationUserInvoices { get; set; }

    }
}

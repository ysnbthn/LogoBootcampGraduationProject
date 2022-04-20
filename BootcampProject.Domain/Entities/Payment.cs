using System;

namespace BootcampProject.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public DateTime BillingDate { get; set; }
        public DateTime PaymentDue { get; set; }
        public DateTime PaymentDate { get; set; } // ödeme sonrası apiden gelecek
        public bool IsPaid { get; set; } // ödeme sonrası apiden gelecek

        public string PaymentType { get; set; }
        public string Amount { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
    }
}

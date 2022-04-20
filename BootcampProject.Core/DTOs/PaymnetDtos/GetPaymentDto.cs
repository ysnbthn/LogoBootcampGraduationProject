using System;

namespace BootcampProject.Core.DTOs.PaymnetDtos
{
    public class GetPaymentDto
    {
        public int Id { get; set; }
        
        public DateTime BillingDate { get; set; }
        public DateTime PaymentDue { get; set; }
        public string PaymentType { get; set; }
        public string Amount { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public bool IsPaid { get; set; }
    }
}

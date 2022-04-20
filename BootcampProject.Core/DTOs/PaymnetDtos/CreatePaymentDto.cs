using System;
using System.Collections.Generic;

namespace BootcampProject.Core.DTOs.PaymnetDtos
{
    public class CreatePaymentDto
    {
        public DateTime BillingDate { get; set; }
        public DateTime PaymentDue { get; set; }
        public string PaymentType { get; set; }
        public string Amount { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }

        //public int Id { get; set; } = 1;
        public List<string> Users { get; set; } = new List<string>();  // foreach yap boş değilse bul
    }
}

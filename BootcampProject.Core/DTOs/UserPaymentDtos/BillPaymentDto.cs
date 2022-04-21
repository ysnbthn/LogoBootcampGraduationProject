using BootcampProject.Domain.MongoDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.UserPaymentDtos
{
    public class BillPaymentDto
    {
        public User User { get => User == null ? new User { CreditCards = new CreditCard[] { } } : User; set => User = value; } 
        public double Amount { get; set; }
        public int InvoiceId { get; set; }
    }
}

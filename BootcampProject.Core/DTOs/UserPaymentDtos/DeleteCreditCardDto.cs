using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.UserPaymentDtos
{
    public class DeleteCreditCardDto
    {
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
    }
}

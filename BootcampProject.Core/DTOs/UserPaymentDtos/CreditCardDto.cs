using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.UserPaymentDtos
{
    public class CreditCardDto
    {
        public string IssuingNetwork { get; set; }
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Balance { get; set; }
        public string CVV { get; set; }
        public string Expiry { get; set; }
    }
}

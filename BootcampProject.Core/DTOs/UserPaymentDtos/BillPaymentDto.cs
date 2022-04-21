using BootcampProject.Domain.MongoDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.UserPaymentDtos
{
    public class BillPaymentDto // apiye giden
    {
        public User User { get; set; } 
        public double Amount { get; set; }
    }
}

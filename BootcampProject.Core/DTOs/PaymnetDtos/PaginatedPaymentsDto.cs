using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.PaymnetDtos
{
    public class PaginatedPaymentsDto
    {
        public List<GetPaymentDto> Payments { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }        
    }
}

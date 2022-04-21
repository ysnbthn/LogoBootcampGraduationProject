using BootcampProject.Core.DTOs.PaymnetDtos;
using BootcampProject.Core.DTOs.UserPaymentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.Abstract
{
    public interface IUserPaymentService
    {
        PaginatedPaymentsDto GetPaginatedUserPayments(int page, bool? paid, int month);

        void Pay(int id);

        void AddCreditCard(CreditCardDto card);
    }
}

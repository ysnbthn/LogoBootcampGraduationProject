using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.PaymnetDtos;
using BootcampProject.Core.DTOs.UserPaymentDtos;
using BootcampProject.Domain.MongoDbEntities;
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

        List<CreditCard> GetCreditCards();

        ResponseDto Pay(BillPaymentDto bill);

        ResponseDto AddCreditCard(CreditCard card);
    }
}

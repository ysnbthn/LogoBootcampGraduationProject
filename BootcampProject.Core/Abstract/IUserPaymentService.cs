using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.PaymnetDtos;
using BootcampProject.Core.DTOs.UserPaymentDtos;
using BootcampProject.Domain.MongoDbEntities;
using System.Collections.Generic;

namespace BootcampProject.Core.Abstract
{
    public interface IUserPaymentService
    {
        PaginatedPaymentsDto GetPaginatedUserPayments(int page, bool? paid, int month);
        List<CreditCard> GetCreditCards();
        ResponseDto Pay(BillDto bill);
        ResponseDto AddCreditCard(CreditCard card);
        ResponseDto DeleteCreditCard(DeleteCreditCardDto card);
    }
}

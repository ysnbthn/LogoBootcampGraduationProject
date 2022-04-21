using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.PaymnetDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.Abstract
{
    public interface IPaymentService
    {
        PaginatedPaymentsDto GetPaginatedPayments(int page, bool? paid, int month);
        ResponseDto AddPayment(CreatePaymentDto entity);
        CreatePaymentDto GetInvoiceForPayment(int invoiceId);
        List<UsersForPaymentDto> GetUsersForPayment();
    }
}

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
        PaginatedPaymentsDto GetPaginatedApartments(int page, bool? paid, int month);
        ResponseDto AddPayment(CreatePaymentDto entity);
        //ResponseDto DeleteApartment(int entityId);
        //UpdateApartmentDto GetApartmentById(int id);

        CreatePaymentDto GetInvoiceForPayment(int invoiceId);
        List<UsersForPaymentDto> GetUsersForPayment();
    }
}

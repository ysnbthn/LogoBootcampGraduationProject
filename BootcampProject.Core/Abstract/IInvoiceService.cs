using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.InvoiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.Abstract
{
    public interface IInvoiceService
    {
        PaginatedInvoicesDto GetPaginatedInvoices(int page);
        ResponseDto AddInvoice(CreateInvoiceDto entity);
        ResponseDto DeleteInvoice(int entityId);
        ResponseDto UpdateInvoice(UpdateInvoiceDto entity);
        UpdateInvoiceDto GetInvoiceById(int id);

        List<InvoiceTypeDto> GetInvoices();
    }
}

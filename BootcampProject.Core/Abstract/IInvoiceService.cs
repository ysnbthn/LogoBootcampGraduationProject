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
        PaginatedInvoicesDto GetPaginatedInvoices(int page, bool? isPaid);
        ResponseDto AddInvoice(CreateInvoiceDto entity);
        //ResponseDto DeleteApartment(int entityId);
        //ResponseDto UpdateApartment(UpdateApartmentDto entity);
        //UpdateApartmentDto GetApartmentById(int id);

        List<InvoiceTypeDto> GetInvoices();
        //List<FlatTypeDto> GetFlatTypes();
        //List<ResidentsDto> GetResidents();
    }
}

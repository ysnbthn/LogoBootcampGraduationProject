using AutoMapper;
using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.InvoiceDtos;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootcampProject.Core.Concretes
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IRepository<Invoice> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseDto AddInvoice(CreateInvoiceDto entity)
        {
            var invoiceExists = _repository.Get().Any(x => x.InvoiceTypeId == entity.InvoiceTypeId &&
                                                           x.PaymentDue.Month == entity.PaymentDue.Month &&
                                                           x.PaymentDue.Year == entity.PaymentDue.Year &&
                                                           x.Amount == decimal.Parse(entity.Amount.Replace(".", ",")) &&
                                                           x.IsDeleted == false);

            if (invoiceExists) return new ResponseDto() { Error = "Invoice already exists", Success = false };

            _repository.Add(_mapper.Map<Invoice>(entity));
            _unitOfWork.Commit();

            return new ResponseDto() { Data = "Invoice added", Success = true };
        }

        public ResponseDto DeleteInvoice(int entityId)
        {
            var invoice = _repository.GetById(entityId);
            
            if (invoice == null) return new ResponseDto { Success = false, Error = "Invoice is not exists!" };

            _repository.Delete(invoice);
            _unitOfWork.Commit();

            return new ResponseDto { Success = true, Data = "Invoice deleted successfully" };
        }

        public UpdateInvoiceDto GetInvoiceById(int id)
        {
            var ınvoice = _repository.GetById(id);

            return _mapper.Map<UpdateInvoiceDto>(ınvoice);
        }

        public List<InvoiceTypeDto> GetInvoices()
        {
            return _mapper.Map<List<InvoiceTypeDto>>(_unitOfWork.Context.InvoiceTypes.ToList());
        }

        public PaginatedInvoicesDto GetPaginatedInvoices(int page, bool? isPaid)
        {
            int totalInvoices = _repository.Get().Count();
            int max = Convert.ToInt32(Math.Ceiling(totalInvoices / 10.0)) == 0 ? 1 : Convert.ToInt32(Math.Ceiling(totalInvoices / 10.0));

            
            var Invoices = 
                isPaid == null 
                ? 
                _repository.Get()
                .Include(x => x.InvoiceType)
                .OrderByDescending(x => x.CreatedAt)
                .Skip(((page >= max ? max : page) - 1) * 10)
                .Take(10)
                .ToList() 
                : 
                _repository.Get()
                .Where(x => x.Paid == isPaid)
                .Include(x => x.InvoiceType)
                .OrderByDescending(x => x.CreatedAt)
                .Skip(((page >= max ? max : page) - 1) * 10)
                .Take(10)
                .ToList();

            return new PaginatedInvoicesDto { Invoices = _mapper.Map<List<GetInvoiceDto>>(Invoices), TotalPages = max, CurrentPage = page };
        }

        public ResponseDto UpdateInvoice(UpdateInvoiceDto entity)
        {
            var invoice = _repository.GetById(entity.Id);

            if (invoice == null) return new ResponseDto { Success = false, Error = "Apartment is not exists!" };

            var invoiceIsExists = _repository.Get().Any(x => x.InvoiceTypeId == entity.InvoiceTypeId &&
                                                             x.PaymentDue.Month == entity.PaymentDue.Month &&
                                                             x.PaymentDue.Year == entity.PaymentDue.Year &&
                                                             x.Amount == decimal.Parse(entity.Amount.Replace(".", ",")) &&
                                                             x.IsDeleted == false);

            if (invoiceIsExists) return new ResponseDto { Success = false, Error = "There is already a invoice in database with same attributes" };

            var mappedInvoice = _mapper.Map(entity, invoice); 

            _repository.Update(mappedInvoice);
            _unitOfWork.Commit();

            return new ResponseDto { Success = true, Data = "User updated successfully" };
        }
    }
}

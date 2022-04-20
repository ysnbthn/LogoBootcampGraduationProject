using AutoMapper;
using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.PaymnetDtos;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootcampProject.Core.Concretes
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IRepository<Payment> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseDto AddPayment(CreatePaymentDto entity)
        {
            var paymentExists = _repository.Get().Any(x => x.PaymentType == entity.PaymentType && x.BillingDate.Month == entity.BillingDate.Month);

            if (paymentExists) return new ResponseDto { Error = "Payment already exists", Success = false };

            //_repository.Add(_mapper.Map<Payment>(entity)); // her user için elle ekle Hangfire kullanmaya çalış
            //_unitOfWork.Commit();
            
            return new ResponseDto { Success = true, Data= "Payment Added" };
        }

        public CreatePaymentDto GetInvoiceForPayment(int invoiceId)
        {
            return _mapper.Map<CreatePaymentDto>(_unitOfWork.Context.Invoices.Include(x => x.InvoiceType).FirstOrDefault(x => x.Id == invoiceId));
        }

        public PaginatedPaymentsDto GetPaginatedApartments(int page, bool? paid, int month)
        {
            int totalPayments = _repository.Get().Count();
            int max = Convert.ToInt32(Math.Ceiling(totalPayments / 10.0)) == 0 ? 1 : Convert.ToInt32(Math.Ceiling(totalPayments / 10.0));


            var payments = (paid != null) ? _repository.Get().OrderByDescending(x => x.PaymentDue).Where(x => x.PaymentDue.Month == month)
                                                .Skip(((page >= max ? max : page) - 1) * 10).Take(10).ToList()
                                          : _repository.Get().OrderByDescending(x => x.PaymentDue).Where(x => x.PaymentDue.Month == month && x.IsPaid == paid)
                                                .Skip(((page >= max ? max : page) - 1) * 10).Take(10).ToList();

            return new PaginatedPaymentsDto { Payments = _mapper.Map<List<GetPaymentDto>>(payments), TotalPages = max, CurrentPage = page };
        }

        public List<UsersForPaymentDto> GetUsersForPayment()
        {
            return _mapper.Map<List<UsersForPaymentDto>>(_unitOfWork.Context.Users.Where(x=> !x.IsDeleted && x.Email != "admin@admin.com").ToList());
        }
    }
}


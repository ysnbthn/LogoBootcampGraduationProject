using AutoMapper;
using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.PaymnetDtos;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using Hangfire;
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
            bool isUserListEmpty = true;
            string userListThatHaveThisPayment = "";

            foreach(var x in entity.Users)
            {
                if(x != null || x != "")
                {
                    isUserListEmpty = false;

                    int id = Convert.ToInt32(x);
                    var user = _unitOfWork.Context.Users.FirstOrDefault(x => x.Id == id);
                    entity.UserName = user.Name + " " + user.Surname;
                    entity.UserEmail = user.Email;
                    entity.UserPhone = user.PhoneNumber;
                    entity.BillingDate = DateTime.Now;

                    var paymentExists = _repository.Get().Any(x => x.PaymentType == entity.PaymentType && x.BillingDate.Month == entity.BillingDate.Month && x.UserEmail == entity.UserEmail);

                    if (!paymentExists)
                    {
                        BackgroundJob.Enqueue(() => AddPaymentsToDb(entity));
                    }
                    else
                    {
                        userListThatHaveThisPayment += $" {entity.UserEmail} ";
                    }

                }
            }

            if(userListThatHaveThisPayment != "")
            {
                return new ResponseDto { Error = $"This payment already exists for user(s): {userListThatHaveThisPayment}.", Success = false };
            }

            return isUserListEmpty ? new ResponseDto { Error = "User list cannot be empty", Success = false } : new ResponseDto { Data = "Payment(s) Added", Success = true };
        }

        public void AddPaymentsToDb(CreatePaymentDto entity)
        {
            _repository.Add(_mapper.Map<Payment>(entity));
            _unitOfWork.Commit();
        }

        public CreatePaymentDto GetInvoiceForPayment(int invoiceId)
        {
            return _mapper.Map<CreatePaymentDto>(_unitOfWork.Context.Invoices.Include(x => x.InvoiceType).FirstOrDefault(x => x.Id == invoiceId));
        }

        public PaginatedPaymentsDto GetPaginatedPayments(int page, bool? paid, int month)
        {
            int totalPayments = _repository.Get().Count();
            int max = Convert.ToInt32(Math.Ceiling(totalPayments / 10.0)) == 0 ? 1 : Convert.ToInt32(Math.Ceiling(totalPayments / 10.0));


            var payments = (paid == null) ? _repository.Get().OrderByDescending(x => x.PaymentDue).Where(x => x.PaymentDue.Month == month)
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


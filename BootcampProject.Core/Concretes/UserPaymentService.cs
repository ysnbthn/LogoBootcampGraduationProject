using AutoMapper;
using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs.PaymnetDtos;
using BootcampProject.Core.DTOs.UserPaymentDtos;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BootcampProject.Core.Concretes
{
    public class UserPaymentService : IUserPaymentService
    {
        private readonly IRepository<Payment> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserPaymentService(IRepository<Payment> repository, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public PaginatedPaymentsDto GetPaginatedUserPayments(int page, bool? paid, int month)
        {
            int totalPayments = _repository.Get().Count();
            int max = Convert.ToInt32(Math.Ceiling(totalPayments / 10.0)) == 0 ? 1 : Convert.ToInt32(Math.Ceiling(totalPayments / 10.0));

            var userMail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);

            var payments = (paid == null) ? _repository.Get().OrderByDescending(x => x.PaymentDue).Where(x => x.PaymentDue.Month == month && x.UserEmail == userMail)
                                                .Skip(((page >= max ? max : page) - 1) * 10).Take(10).ToList()
                                          : _repository.Get().OrderByDescending(x => x.PaymentDue).Where(x => x.PaymentDue.Month == month && x.IsPaid == paid && x.UserEmail == userMail)
                                                .Skip(((page >= max ? max : page) - 1) * 10).Take(10).ToList();

            return new PaginatedPaymentsDto { Payments = _mapper.Map<List<GetPaymentDto>>(payments), TotalPages = max, CurrentPage = page };
        }

        public void Pay(int id)
        {
            throw new NotImplementedException();
        }
        public void AddCreditCard(CreditCardDto card)
        {
            var apiUrl = "https://localhost:5001/CreditCardPayment"; // değiş

            
        }        
    }
}


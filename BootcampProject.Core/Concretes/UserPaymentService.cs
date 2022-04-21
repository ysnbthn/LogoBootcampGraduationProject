using AutoMapper;
using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.PaymnetDtos;
using BootcampProject.Core.DTOs.UserPaymentDtos;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using BootcampProject.Domain.MongoDbEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

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

        public ResponseDto AddCreditCard(CreditCard card)
        {
            HttpClient client = new HttpClient();
            var url = new Uri("https://localhost:44355/api/CreditCardPayment/NewCard");

            var user = new User
            {
                Email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email),
                CreditCards = new CreditCard[]
                {
                    card
                }
            };

            var serilizedObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            var requestContent = new StringContent(serilizedObject, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, requestContent).Result;

            return new ResponseDto { Success = true, Data = "Credit Card added" };
        }

        public List<CreditCard> GetCreditCards()
        {
            HttpClient client = new HttpClient();

            var url = new Uri("https://localhost:44355/api/CreditCardPayment/" + _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email));

            HttpResponseMessage response = client.GetAsync(url).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<CreditCard>>(responseBody).ToList();
        }

        public ResponseDto Pay(BillPaymentDto bill)
        {
            HttpClient client = new HttpClient();

            var url = new Uri("https://localhost:44355/api/CreditCardPayment/" + _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email));

            HttpResponseMessage response = client.GetAsync(url).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            var card = JsonConvert.DeserializeObject<List<CreditCard>>(responseBody).ToList().FirstOrDefault(x=>x.CardNumber == bill.User.CreditCards[0].CardNumber);

            url = new Uri("https://localhost:44355/api/CreditCardPayment/MakePayment");

            bill.User.Email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            bill.User.CreditCards[0] = card;

            var serilizedObject = Newtonsoft.Json.JsonConvert.SerializeObject(bill);
            var requestContent = new StringContent(serilizedObject, Encoding.UTF8, "application/json");

            var result = client.PostAsync(url, requestContent).Result;

            var payment = _repository.GetById(bill.InvoiceId);
            payment.PaymentDate = DateTime.Now;
            payment.IsPaid = true;
            _repository.Update(payment);
            _unitOfWork.Commit();
            

            return new ResponseDto { Success = true, Data = "Credit Card added" };
        }
    }
}


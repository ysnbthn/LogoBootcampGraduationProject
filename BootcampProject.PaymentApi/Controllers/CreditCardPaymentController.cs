using BootcampProject.Core.DTOs.UserPaymentDtos;
using BootcampProject.DataAccess.MongoDB.Repository.Abstract;
using BootcampProject.Domain.MongoDbEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampProject.PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardPaymentController : ControllerBase
    {
        private readonly ICreditCardPaymentRepository _repository;

        public CreditCardPaymentController(ICreditCardPaymentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{email}")]
        public List<CreditCard> GetCards(string email)
        {
            return _repository.GetCreditCardsOfUser(email);
        }

        [HttpPost]
        [Route("/NewCreditCard")]
        public IActionResult NewCard(User creditCard)
        {
            _repository.AddCreditCard(creditCard);
            return Ok();
        }

        [HttpPost]
        [Route("/NewUser")]
        public IActionResult NewUser([FromBody] User user)
        {
            _repository.AddUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("/MakePayment")]
        public IActionResult MakePayment([FromBody] User user, double amount)
        {
            var result = _repository.MakePayment(user, amount);
            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpDelete]
        [Route("/DeleteCreditCard/{email}/{cardNumber}")]
        public IActionResult DeleteCard(string email, string cardNumber)
        {
            _repository.DeleteCreditCard(email, cardNumber);
            return Ok();
        }
    }
}

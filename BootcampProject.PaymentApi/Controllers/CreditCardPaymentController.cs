using BootcampProject.Core.DTOs.UserPaymentDtos;
using BootcampProject.DataAccess.MongoDB.Repository.Abstract;
using BootcampProject.Domain.MongoDbEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpPost("NewCard")]
        public IActionResult NewCard(User creditCard)
        {
            _repository.AddCreditCard(creditCard);
            return Ok();
        }

        [HttpPost]
        [Route("NewUser")]
        public IActionResult NewUser([FromBody] User user)
        {
            _repository.AddUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("MakePayment")]
        public IActionResult MakePayment(BillPaymentDto bill)
        {
            var result = _repository.MakePayment(bill.User, bill.Amount);
            return result.Success ? Ok(result.Data) : BadRequest(result.Error);
        }

        [HttpPost("DeleteCard")]
        public IActionResult DeleteCard(DeleteCreditCardDto card)
        {
            _repository.DeleteCreditCard(card.Email, card.CreditCardNumber);
            return Ok();
        }
    }
}

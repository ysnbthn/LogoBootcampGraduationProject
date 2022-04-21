using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs.UserPaymentDtos;
using BootcampProject.Domain.MongoDbEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace BootcampProject.Web.Controllers
{
    public class UserPaymentController : Controller
    {
        private readonly IUserPaymentService _userPaymentService;

        public UserPaymentController(IUserPaymentService userPaymentService)
        {
            _userPaymentService = userPaymentService;
        }

        public IActionResult Index(int page, bool? paid, int month)
        {
            if (page == 0) page = 1;
            if (month == 0) month = DateTime.Now.Month;

            var userPayments = _userPaymentService.GetPaginatedUserPayments(page, paid, month);

            return View(userPayments);
        }

        public IActionResult CreditCards()
        {
            var cards = _userPaymentService.GetCreditCards();
            return View(cards);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreditCard card)
        {
            var result = _userPaymentService.AddCreditCard(card);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            }

            TempData["Error"] = result.Error;
            return View();
        }
        

        public IActionResult Pay(int id)
        {
            ViewBag.CreditCards = _userPaymentService.GetCreditCards().Select(x => new SelectListItem { Text = x.CardNumber, Value = x.CardNumber }).ToList();
            ViewBag.id = id;
            return View();
        }

        [HttpPost("{paymentId}")]
        public IActionResult Pay([FromForm] BillPaymentDto bill)
        {
            var result = _userPaymentService.Pay(bill);
            return View();
        }

    }
}

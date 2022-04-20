using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs.PaymnetDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace BootcampProject.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Index(int page, bool? paid, int month)
        {
            if (page == 0) page = 1;
            if (month == 0) month = DateTime.Now.Month;

            var paymentDtos = _paymentService.GetPaginatedPayments(page, paid, month);

            return View(paymentDtos);
        }

        //[HttpGet("Payment/Create/{invoiceId}")]
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.InvoiceTypes = _paymentService.GetUsersForPayment().Select(x => new SelectListItem { Text = x.Email, Value = x.Id.ToString() }).ToList();

            CreatePaymentDto paymentModel = _paymentService.GetInvoiceForPayment(id);

            return View(paymentModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePaymentDto paymentModel)
        {

            if (!ModelState.IsValid)
            {
                throw new Exception("Payment model is not valid");
            }
   
            var result = _paymentService.AddPayment(paymentModel);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", "Invoice", TempData);
            }

            ViewBag.InvoiceTypes = _paymentService.GetUsersForPayment().Select(x => new SelectListItem { Text = x.Email, Value = x.Id.ToString() }).ToList();
            TempData["Error"] = result.Error;

            return View(paymentModel);
        }

    }
}

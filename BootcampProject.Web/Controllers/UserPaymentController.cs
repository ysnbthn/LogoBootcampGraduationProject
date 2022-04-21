using BootcampProject.Core.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;

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
    }
}

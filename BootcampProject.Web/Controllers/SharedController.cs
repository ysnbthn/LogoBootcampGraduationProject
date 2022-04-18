using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BootcampProject.Web.Controllers
{
    [AllowAnonymous]
    public class SharedController : Controller
    {
        
        [HttpGet("/Oops")]
        public IActionResult Exception()
        {
            return View();
        }

        [HttpGet("/404")]
        public IActionResult NotFound()
        {
            return View();
        }

        [HttpGet("/exception")]
        public IActionResult TriggerException()
        {
            throw new Exception("exception thrown");
        }
    }
}

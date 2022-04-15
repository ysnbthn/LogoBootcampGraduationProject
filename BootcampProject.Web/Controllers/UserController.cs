using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using BootcampProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BootcampProject.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] int page = 1)
        {
            var users = _userService.GetPagedUsers(page);

            return View(new UserActionDto { Users = users });
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var result = _userService.AddUser(user);

            if (result.Success) return RedirectToAction("Index");

            TempData["Error"] = result.Error;

            return View();
        }

        

        [HttpPut]
        public IActionResult Update([FromForm] UpdateUserDto user, [FromQuery] int page = 1)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.UpdateUser(user);

                var users = _userService.GetPagedUsers(page);

                return View("Index", new UserActionDto { Users = users, Result = result });
            }

            return View("Index", new UserActionDto { Users = _userService.GetPagedUsers(1), EditUser = user });
        }

        
    }
}

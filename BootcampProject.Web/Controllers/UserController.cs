using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BootcampProject.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int page)
        {
            if(page == 0) page = 1;
            return View(_userService.GetPagedUsers(page));
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

            if (result.Success) 
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            } 
                

            TempData["Error"] = result.Error;

            return RedirectToAction("Index", TempData);
        }

        [HttpGet("User/Update/{id}")]
        public IActionResult Update(int id)
        {
            var userToUpdate = _userService.GetUserById(id);
            return View(userToUpdate);
        }

        [HttpPost("User/Update/{id}")]
        public IActionResult Update([FromForm] UpdateUserDto user, int id)
        {
            user.Id = id;
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var result = _userService.UpdateUser(user);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            }

            TempData["Error"] = result.Error;

            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var result = _userService.DeleteUser(id);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            }

            TempData["Message"] = result.Error;

            return RedirectToAction("Index", TempData);
        }

    }
}

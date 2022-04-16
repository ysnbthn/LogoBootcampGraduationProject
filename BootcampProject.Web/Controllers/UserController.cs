using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BootcampProject.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int page = 1)
        {
            
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
                TempData["Success"] = result.Data;
                return RedirectToAction("Index", TempData);
            } 
                

            TempData["Error"] = result.Error;

            return RedirectToAction("Index", TempData);
        }

        [HttpGet("{id}")]
        public IActionResult Update(string id)
        {
            var userToUpdate = _userService.GetUserById(id);
            return View(userToUpdate);
        }

        [HttpPost("{id}")]
        public IActionResult Update([FromForm] UpdateUserDto user, string id)
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

        public IActionResult Delete(string id)
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

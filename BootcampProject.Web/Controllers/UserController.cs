using BootcampProject.Core.Abstract;
using BootcampProject.Domain.Entities;
using BootcampProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var users = _userService.GetPagedUsersAsync(page);

            return View(new UserActionViewModel { Users = users, EditUser = new ApplicationUser() });
        }

        [HttpPut]
        public IActionResult Update([FromForm] ApplicationUser user, [FromQuery] int page = 1)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
            }

            var users = _userService.GetPagedUsersAsync(page);

            return View("Index", new UserActionViewModel { Users = users, EditUser = new ApplicationUser() });
        }
    }
}

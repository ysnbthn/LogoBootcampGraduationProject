using BootcampProject.Domain.Entities;
using BootcampProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BootcampProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            if (User.Identity.IsAuthenticated) {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("IndexAdmin", "Home");
                }
                else if (User.IsInRole("Basic"))
                {
                    return RedirectToAction("IndexUser", "Home");
                }
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromForm] LoginViewModel login)
        {
            if (!ModelState.IsValid) return View(login);

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);

            if (result.Succeeded)
            {
                // User.IsInRole not working here

                var user = await _signInManager.UserManager.FindByEmailAsync(login.Email);

                if (await _userManager.IsInRoleAsync(user, "Admin")) {
                    return RedirectToAction("IndexAdmin", "Home");
                }
                
                return RedirectToAction("IndexUser", "Home");
            }

            TempData["LoginError"] = "Invalid login attempt";
            return View("Login", login);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult IndexAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Basic")]
        public IActionResult IndexUser()
        {
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            
            return RedirectToAction("Login", "Home");
        }


        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

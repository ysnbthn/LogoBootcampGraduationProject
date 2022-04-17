using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs.ApartmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BootcampProject.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            return View(_apartmentService.GetPagedApartments(page));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = _apartmentService.GetResidents().Select(x => new SelectListItem { Text = x.Email, Value = x.OwnerOrHirerId.ToString() }).ToList();
            ViewBag.Blocks = _apartmentService.GetBlocks();
            ViewBag.FlatTypes = _apartmentService.GetFlatTypes();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateApartmentDto apartment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = _apartmentService.GetResidents().Select(x => new SelectListItem { Text = x.Email, Value = x.OwnerOrHirerId.ToString() }).ToList();
                ViewBag.Blocks = _apartmentService.GetBlocks();
                ViewBag.FlatTypes = _apartmentService.GetFlatTypes();
                
                return View(apartment);
            }

            var result = _apartmentService.AddApartment(apartment);
            

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            }
            
            TempData["Message"] = result.Error;
            return RedirectToAction("Index", TempData);
        }

        public IActionResult Delete(int id)
        {
            var result = _apartmentService.DeleteApartment(id);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            }

            TempData["Message"] = result.Error;

            return RedirectToAction("Index", TempData);
        }

        [HttpGet("Apartment/Update/{apartmentId}")]
        public IActionResult Update(int apartmentId)
        {
            var userToUpdate = _apartmentService.GetApartmentById(apartmentId);

            ViewBag.Users = _apartmentService.GetResidents().Select(x => new SelectListItem { Text = x.Email, Value = x.OwnerOrHirerId.ToString() }).ToList();
            ViewBag.Blocks = _apartmentService.GetBlocks();
            ViewBag.FlatTypes = _apartmentService.GetFlatTypes();

            return View(userToUpdate);
        }

        [HttpPost("Apartment/Update/{apartmentId}")]
        public IActionResult Update([FromForm] UpdateApartmentDto apartment, int apartmentId)
        {
            apartment.Id = apartmentId;
            if (!ModelState.IsValid)
            {
                ViewBag.Users = _apartmentService.GetResidents().Select(x => new SelectListItem { Text = x.Email, Value = x.OwnerOrHirerId.ToString() }).ToList();
                ViewBag.Blocks = _apartmentService.GetBlocks();
                ViewBag.FlatTypes = _apartmentService.GetFlatTypes();

                return View(apartment);
            }

            var result = _apartmentService.UpdateApartment(apartment);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            }

            TempData["Error"] = result.Error;

            return RedirectToAction("Index", TempData);
        }
    }
}

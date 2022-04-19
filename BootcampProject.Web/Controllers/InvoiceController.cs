using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs.InvoiceDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace BootcampProject.Web.Controllers
{
    public class InvoiceController : Controller
    {
        IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public IActionResult Index(int page, bool? isPaid)
        {
            if (page == 0) page = 1;
            return View(_invoiceService.GetPaginatedInvoices(page, isPaid));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.InvoiceTypes = ViewBag.InvoiceTypes = _invoiceService.GetInvoices().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateInvoiceDto invoice)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.InvoiceTypes = _invoiceService.GetInvoices().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

                return View(invoice);
            }

            var result = _invoiceService.AddInvoice(invoice);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            }

            ViewBag.InvoiceTypes = _invoiceService.GetInvoices().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            TempData["Error"] = result.Error;

            return View(invoice);
        }

        [HttpPost]
        public IActionResult Delete([FromForm] int invoiceId)
        {
            var result = _invoiceService.DeleteInvoice(invoiceId);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", "Invoice", TempData);
            }

            TempData["Error"] = result.Error;

            return RedirectToAction("Index", "Invoice", TempData);
        }

        

        [HttpGet("Invoice/Update/{invoiceId}")]
        public IActionResult Update(int invoiceId)
        {
            var invoiceToUpdate = _invoiceService.GetInvoiceById(invoiceId);

            ViewBag.InvoiceTypes = _invoiceService.GetInvoices().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View(invoiceToUpdate);
        }

        [HttpPost("Invoice/Update/{invoiceId}")]
        public IActionResult Update([FromForm] UpdateInvoiceDto invoice, int invoiceId)
        {
            invoice.Id = invoiceId;
            if (!ModelState.IsValid)
            {
                ViewBag.InvoiceTypes = _invoiceService.GetInvoices().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

                return View(invoice);
            }

            var result = _invoiceService.UpdateInvoice(invoice);

            if (result.Success)
            {
                TempData["Message"] = result.Data;
                return RedirectToAction("Index", TempData);
            }

            TempData["Error"] = result.Error;
            ViewBag.InvoiceTypes = _invoiceService.GetInvoices().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View("Index", TempData);
        }
    }
}

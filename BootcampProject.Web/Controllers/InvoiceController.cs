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
            decimal getValue = invoice.Amount;
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
    }
}

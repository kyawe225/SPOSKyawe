using Microsoft.AspNetCore.Mvc;
using SPOS.MVC.Areas.Admin.Models;
using SPOS.Persistance.Context;
using SPOS.Persistance.Tables;
using System.Diagnostics;

namespace SPOS.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private SPOSContext _context;
        public ProductController(SPOSContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Debug.WriteLine(_context.products.ToList()[1].Id.ToString());
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<CompanyListViewModel> companies=_context.companies.Select(p => new CompanyListViewModel
            {
                Name=p.Name,
                Id=p.Id.ToString()
            }).ToList();
            ViewData["CompanyList"] = companies;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult CreateAction(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductTable product = new ProductTable()
                {
                    CompanyId=Guid.Parse(model.CompanyId),
                    Name=model.Name,
                    Description=model.Description,
                    NumberOfItems=model.NumberOfItems,
                    Price=model.Price
                };
                _context.products.Add(product);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Created Product Successfully";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Create not Successfully.";
            IEnumerable<CompanyListViewModel> companies = _context.companies.Select(p => new CompanyListViewModel
            {
                Name = p.Name,
                Id = p.Id.ToString()
            }).ToList();
            ViewData["CompanyList"] = companies;
            return View(model);
        }
    }
}

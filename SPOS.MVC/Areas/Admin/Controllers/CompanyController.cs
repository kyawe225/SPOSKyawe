using Microsoft.AspNetCore.Mvc;
using SPOS.MVC.Areas.Admin.Models;
using SPOS.Persistance.Context;
using SPOS.Persistance.Tables;

namespace SPOS.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly SPOSContext _context;
        public CompanyController(SPOSContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CompanyCreateViewModel());
        }
        [HttpPost]
        [ActionName("create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAction(CompanyCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                CompanyTable company = new CompanyTable()
                {
                    Address = model.Address,
                    Description = model.Description,
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                };
                _context.companies.Add(company);
                _context.SaveChanges();
                return RedirectToAction("Index","Company",new { area="Admin" });
            }
            return View(model);
        } 
    }
}

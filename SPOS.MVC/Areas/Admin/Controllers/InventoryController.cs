using Microsoft.AspNetCore.Mvc;
using SPOS.MVC.Areas.Admin.Models;
using SPOS.Persistance.Context;
using SPOS.Persistance.Tables;
using Microsoft.EntityFrameworkCore;

namespace SPOS.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InventoryController : Controller
    {
        private readonly SPOSContext context;
        public InventoryController(SPOSContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<ProductListViewModel> products = context.products.Select(p => new ProductListViewModel
            {
                Id = p.Id.ToString(),
                Name = p.Name
            }).ToList();
            ViewData["product_list"] = products;
            return View();
        }
        [HttpPost]
        [ActionName("create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAction(InventoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                InventoryTable row = new InventoryTable()
                {
                    Name = model.Name,
                    ArrivedDate = model.ArrivedDate,
                    ExpireDate = model.ExpireDate,
                    Perishable = model.Perishable,
                    isQualified = model.isQualified,
                    Description = model.Description,
                    isSellable = model.isSellable,
                    NumberOfItems = model.NumberOfItems,
                    ProductId = Guid.Parse(model.ProductId),
                };
                context.inventory.Add(row);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            IEnumerable<ProductListViewModel> products = context.products.Select(p => new ProductListViewModel
            {
                Id = p.Id.ToString(),
                Name = p.Name
            }).ToList();
            ViewData["product_list"] = products;
            return View();
        }
        [HttpGet]
        public IActionResult Approve()
        {
            IEnumerable<InventoryApproveViewModel> items = context.inventory.Include(p => p.Product).ThenInclude(p => p.Company).Where(p => !(p.isSellable && p.isQualified)).OrderBy(p => p.CreatedAt).Select(p => new InventoryApproveViewModel
            {
                Id=p.Id.ToString(),
                Name = p.Name,
                ArrivedDate = p.ArrivedDate,
                ExpireDate = p.ExpireDate,
                Perishable = p.Perishable,
                isSellable = p.isSellable,
                isQualified = p.isQualified,
                companyId = p.Product.CompanyId.ToString(),
                companyName = p.Product.Company.Name,
                NumberOfItems = p.NumberOfItems,
                ProductId = p.ProductId.ToString(),
                productName = p.Product.Company.Name,
                Description = ""
            }).ToList();
            return View(items);
        }
        [HttpPost]
        [ActionName("approve")]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveAction(string Id)
        {
            Guid guid;
            bool isGuid = Guid.TryParse(Id, out guid);
            if (isGuid)
            {
                if (ModelState.IsValid)
                {
                    InventoryTable? inventory = context.inventory.Where(p => p.Id.Equals(guid)).FirstOrDefault();
                    if (inventory != null)
                    {
                        inventory.isSellable = true;
                        inventory.isQualified = true;
                        context.Update<InventoryTable>(inventory);
                        context.SaveChanges();
                        return Ok(new { message = "Approve Successfully" });
                    }
                    return Ok(new { message = "Inventory Item Cannot Found" });
                }
            }
            return BadRequest(new { status = "400", message = "Request need Product Serial Number" });
        }
    }
}

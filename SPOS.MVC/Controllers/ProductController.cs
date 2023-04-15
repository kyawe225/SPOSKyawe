using Microsoft.AspNetCore.Mvc;
using SPOS.Persistance.Context;
using SPOS.Persistance.Tables;
using SPOS.MVC.Models;

namespace SPOS.MVC.Controllers
{
    public class ProductController : Controller
    {
        private ILogger<ProductController> _logger;
        private SPOSContext _context;
        public ProductController(ILogger<ProductController> logger,SPOSContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpPost]
        public IActionResult FindProduct(string Id)
        {
            try
            {
                Guid guid = Guid.Parse(Id);
                ProductDetailViewModel? product = _context.products.Where(p => p.Id.Equals(guid)).Select(p => new ProductDetailViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Id = p.Id.ToString()
                }).FirstOrDefault();
                //ProductDetailViewModel product = new ProductDetailViewModel()
                //{
                //    Name="Hello World",
                //    Price=1000,
                //    Id=Guid.NewGuid().ToString()
                //};
                if (product != null)
                {
                    _logger.LogInformation("Product Found!");
                    return Ok(new { status = 200, data = product });
                }
            }
            catch(Exception ex)
            {
                _logger.LogDebug(ex.StackTrace);
            }
            return BadRequest(new { status = 400, message = "No Product Found" });
        }
    }
}

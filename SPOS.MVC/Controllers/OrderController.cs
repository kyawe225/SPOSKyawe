using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using SPOS.MVC.Models;
using SPOS.Persistance.Context;
using SPOS.Persistance.Tables;

namespace SPOS.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly SPOSContext _context;
        private readonly ILogger _logger;
        public OrderController(SPOSContext context,ILogger<OrderController> logger)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ActionName("accept")]
        public IActionResult acceptOrders(OrderDetailCreateViewModel[] ids)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrderTable order = new OrderTable()
                    {
                        Name = Guid.NewGuid().ToString(),
                        //UserId = Guid.NewGuid()
                    };
                    IList<OrderDetail> details = new List<OrderDetail>();
                    foreach (OrderDetailCreateViewModel item in ids)
                    {
                        OrderDetail orderDetail = new OrderDetail()
                        {
                            Name = Guid.NewGuid().ToString(),
                            Items = item.number_of_items,
                            ProductId = Guid.Parse(item.id),
                            SubTotalPrice = item.number_of_items * item.price,
                            OrderId = order.Id
                            
                        };
                        details.Add(orderDetail);
                    }
                    _context.orders.Add(order);
                    _context.orderDetails.AddRange(details);
                    _context.SaveChanges();
                    _logger.LogInformation("Save Order Successfully");
                    return Ok(new { status = 200, message = "Order Save Successfully" });
                }
                return BadRequest(new { status = 400, message = "Please try Again" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = 400, message = "Please try Again" });
            }
        }
    }
}



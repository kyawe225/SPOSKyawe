using Microsoft.AspNetCore.Mvc;

namespace SPOS.MVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}

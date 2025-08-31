using Microsoft.AspNetCore.Mvc;

namespace Day29_ECommerce_assignment2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
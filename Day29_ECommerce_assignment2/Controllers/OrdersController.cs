using Day29_ECommerce_assignment2.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Day29_ECommerce_assignment2.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilter))]
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
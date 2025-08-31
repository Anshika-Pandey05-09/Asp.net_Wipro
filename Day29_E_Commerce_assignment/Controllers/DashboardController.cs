using Microsoft.AspNetCore.Mvc;

namespace Day29_E_Commerce_assignment.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet("Dashboard")]
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated == true && User.IsInRole("Admin"))
                return View("AdminDashboard");

            return View("UserDashboard");
        }
    }
}

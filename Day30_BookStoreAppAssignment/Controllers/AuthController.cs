using Microsoft.AspNetCore.Mvc;

namespace Day30_BookStoreAppAssignment.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
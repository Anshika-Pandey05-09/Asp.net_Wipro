using Microsoft.AspNetCore.Mvc;
using Day28_Assignment2.Models;

namespace Day28_Assignment2.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: /UserRegistration/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /UserRegistration/Register
        [HttpPost]
        public IActionResult Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                // ✅ Normally you'd save to DB, here we just show success
                return View("Success", model);
            }

            // If validation fails, reload form with errors
            return View(model);
        }
    }
}
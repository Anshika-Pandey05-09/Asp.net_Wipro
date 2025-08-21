using Microsoft.AspNetCore.Mvc;
using Day27_Assignment2.Models;

namespace Day27_Assignment2.Controllers
{
    public class UserController : Controller
    {
        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // For demo: just show data on a result page
                return View("Result", user);
            }
            return View(user);
        }
    }
}
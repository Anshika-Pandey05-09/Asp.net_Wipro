using Day29_E_Commerce_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Day29_E_Commerce_assignment.Controllers
{
    [Route("Users")]
    public class UsersController : Controller
    {
        [HttpGet("{username}/Orders")]
        public IActionResult Orders(string username)
        {
            var orders = new List<Order>
            {
                new Order { OrderId = 1, Item = "Laptop", Amount = 75000 },
                new Order { OrderId = 2, Item = "Book", Amount = 500 }
            };
            ViewBag.Username = username;
            return View(orders);
        }
    }
}

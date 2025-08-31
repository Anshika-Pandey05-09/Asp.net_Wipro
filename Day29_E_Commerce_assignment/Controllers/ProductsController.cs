using Day29_E_Commerce_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Day29_E_Commerce_assignment.Controllers
{
    [Route("Products")]
    public class ProductsController : Controller
    {
        // Matches /Products/{category}/{id}
        [HttpGet("{category}/{id:int}")]
        public IActionResult Details(string category, int id)
        {
            var product = new Product
            {
                Id = id,
                Category = category,
                Name = $"{category} Product #{id}",
                Price = 199.99m
            };
            return View(product);
        }

        // Matches /Products/Filter/{category}/{priceRange}
        [HttpGet("Filter/{category:validCategory}/{priceRange:priceRange}")]
        public IActionResult Filter(string category, string priceRange)
        {
            var model = new List<Product>
            {
                new Product { Id = 1, Category = category, Name = $"{category} Item A", Price = 250 },
                new Product { Id = 2, Category = category, Name = $"{category} Item B", Price = 450 }
            };
            ViewBag.Range = priceRange;
            return View(model);
        }
    }
}

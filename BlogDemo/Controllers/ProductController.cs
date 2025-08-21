using BlogDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Controllers
{
    // Product controller for managing products
    public class ProductController : Controller
    {
        // In-memory data store
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "Description for Product 1", Price = 10 },
            new Product { Id = 2, Name = "Printer", Description = "Description for Product 2", Price = 20 },
            new Product { Id = 3, Name = "Speaker", Description = "Description for Product 3", Price = 30 }
        };

        // Action methods
        // Create Product
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Index
        public IActionResult Index()
        {
            return View(products);
        }

        // Details
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
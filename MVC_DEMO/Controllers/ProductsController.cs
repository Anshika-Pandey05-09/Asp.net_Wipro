//Adding model
using MVC_DEMO.Models; // Uncomment if you have a Product model to use
using Microsoft.AspNetCore.Mvc;

namespace MVC_DEMO.Controllers
{
    public class ProductsController : Controller
    {
        //Controllers are responsible for handling user input and returning responses

        // get: /Products/Index
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.00M },
                new Product { Id = 2, Name = "Smartphone", Price = 250.00M },
                new Product { Id = 3, Name = "Tablet", Price = 550.00M }

            };
            return View(products); // Passing the list of products to the view

        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day27_Assignment1.Models;
using Day27_Assignment1.Pages;

namespace Day27_Assignment1.Pages.Products
{
    public class ProductDetailModel : PageModel
    {
        public Product? Product { get; set; }

        public IActionResult OnGet(int id)
        {
            // Access the static product list from ProductsModel
            var allProducts = typeof(ProductsModel)
                                .GetField("_products", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                                ?.GetValue(null) as List<Product>;

            Product = allProducts?.FirstOrDefault(p => p.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
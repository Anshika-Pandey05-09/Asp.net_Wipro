using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day27_Assignment1.Models;

namespace Day27_Assignment1.Pages
{
    public class ProductsModel : PageModel
    {
        // Internal static storage for all products
        private static List<Product> _products = new List<Product>();

        // This instance property is used by Razor
        public List<Product> Products { get; set; } = new List<Product>();

        [BindProperty]
        public Product NewProduct { get; set; } = new Product();

        [BindProperty]
        public string CategoryInput { get; set; } = string.Empty;

        public void OnGet()
        {
            // Load products into the instance property so Razor can access it
            Products = _products;
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(CategoryInput))
            {
                var categories = CategoryInput.Split(',')
                                              .Select(c => new Category { Name = c.Trim() })
                                              .ToList();
                NewProduct.Categories.AddRange(categories);
            }

            // Auto-generate ProductID
            NewProduct.ProductID = _products.Count + 1;

            _products.Add(NewProduct);

            return RedirectToPage();
        }
    }
}
// Implement the ProductController
using Day30_EmployeeManagement.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Day30_EmployeeManagement.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        // public IActionResult Index()
        // {
        //     return Content("Product list: [product1, product2, product3]");
        // }

        // [HttpGet("{id}")]
        // public IActionResult Details(int id)
        // {
        //     // return Content($"Product details for product {id}");
        //     // Displaying time taken to retrieve product details
        //     // var watch = System.Diagnostics.Stopwatch.StartNew();
        //     // // Simulate data retrieval
        //     // System.Threading.Thread.Sleep(5000);
        //     // watch.Stop();
        //     return Content($"Product details for product {id}. ");
        //     // return Content($"Product details for product {id}. Time taken: {watch.ElapsedMilliseconds} ms");
        // }


        [ServiceFilter(typeof(ProductCacheResource))]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ContentResult contentResult = new ContentResult
            {
                Content = $"Details for product id: {id} fetched at " + DateTime.UtcNow,
                ContentType = "text/plain"
            };
            return contentResult;
        }
    }
}
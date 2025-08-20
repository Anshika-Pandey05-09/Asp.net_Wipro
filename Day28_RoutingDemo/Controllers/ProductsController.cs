using Microsoft.AspNetCore.Mvc;

namespace Day28_RoutingDemo.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        ViewData["Message"] = "Products Catalog";
        return View();
    }
    public IActionResult Details(int id)
    {
        ViewData["ProductId"] = id;
        ViewData["Message"] = $"Details for product with ID: {id}";
        return View();
    }
}
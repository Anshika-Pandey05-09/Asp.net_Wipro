using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Day28_RoutingDemo.Models;

namespace Day28_RoutingDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page."; 
        return View();
    }

     public IActionResult Contact(string department = "general")
    {
        ViewData["Department"] = department ;
        ViewData["Message"] = $"Contact page for {department} department.";
        return View();
    }
}

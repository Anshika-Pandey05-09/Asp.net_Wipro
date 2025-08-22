using Day30_EmployeeManagement.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day30_EmployeeManagement.Controllers
{
    // [ServiceFilter(typeof(AuthorizationFilter))]
    [Route("reports")]
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("salary")]
        [ServiceFilter(typeof(AuthorizationFilterContext))]
        public IActionResult Salary() => Content("Salary report: [confidential]");


    }
}
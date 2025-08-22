using Day30_EmployeeManagement.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

// Here we will use the Log Filter in this order controller GET()

namespace Day30_EmployeeManagement.Controllers
{
    [Route("orders")]
    [ServiceFilter(typeof(ExceptionFilter))] // Applying the ExceptionFilter globally for this controller
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        public OrderController(ILogger<OrderController> logger) => _logger = logger;

        [HttpGet("{id}")]
        // [ServiceFilter(typeof(LogFilter))]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Getting order {Id}", id);
            return Content($"Order details for order {id}");
        }

        // Adding exception filter here
        // [ServiceFilter(typeof(ExceptionFilter))]

        [HttpGet("error-test/{id}")]
        public IActionResult GetWithError(int id)
        {
            _logger.LogInformation("Getting order {Id}", id);
            throw new Exception("Test exception");
        }

        // creating Index
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Getting all orders");
            throw new NotImplementedException("This method is not implemented yet.");
        }
    }
}
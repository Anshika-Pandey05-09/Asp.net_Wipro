using Microsoft.AspNetCore.Mvc.Filters;
using Day29_ECommerce_assignment2.Services;

namespace Day29_ECommerce_assignment2.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILoggingService _logger;

        public LoggingFilter(ILoggingService logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.Log($"Request: {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Log($"Response: {context.HttpContext.Response.StatusCode}");
        }
    }
}
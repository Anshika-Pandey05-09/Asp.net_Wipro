using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Day29_ECommerce_assignment2.Services;

namespace Day29_ECommerce_assignment2.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILoggingService _logger;

        public GlobalExceptionFilter(ILoggingService logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.Log($"Exception: {context.Exception.Message}");
            context.Result = new ViewResult { ViewName = "Error" };
            context.ExceptionHandled = true;
        }
    }
}
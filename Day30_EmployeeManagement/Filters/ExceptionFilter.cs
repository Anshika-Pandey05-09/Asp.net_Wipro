using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Day30_EmployeeManagement.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        // private readonly ILogger<ExceptionFilter> _logger;
        // public ExceptionFilter(ILogger<ExceptionFilter> logger) => _logger = logger;

        public void OnException(ExceptionContext context)
        {
            // _logger.LogError(context.Exception, "An error occurred while processing your request.");
            // context.Result = new StatusCodeResult(500);

            var problem = new ProblemDetails
                    {
                        Title = "Unexpected error",
                        Detail = "Please try again later.",
                        Status = StatusCodes.Status500InternalServerError,
                        Instance = context.HttpContext.Request.Path
                    };
            context.Result = new ObjectResult(problem)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
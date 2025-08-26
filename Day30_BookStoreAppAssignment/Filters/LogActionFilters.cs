using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Day30_BookStoreAppAssignment.Filters
{
    public class LogActionFilter : IActionFilter, IExceptionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine($"[LOG] Action {context.ActionDescriptor.DisplayName} starting at {DateTime.Now}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine($"[LOG] Action {context.ActionDescriptor.DisplayName} finished at {DateTime.Now}");
        }

        public void OnException(ExceptionContext context)
        {
            Debug.WriteLine($"[ERROR] Exception in {context.ActionDescriptor.DisplayName}: {context.Exception.Message}");
            context.ExceptionHandled = true;

            context.Result = new Microsoft.AspNetCore.Mvc.ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}
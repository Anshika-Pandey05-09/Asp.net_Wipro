using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;


// public class LogFilter : IActionFilter
// {

//     private readonly ILogger<LogFilter> _logger;
//     public LogFilter(ILogger<LogFilter> logger) => _logger = logger;

//     public void OnActionExecuting(ActionExecutingContext context)
//     {
//         // Simple input guard
//         if (context.ActionArguments.TryGetValue("id", out var val) &&
//             val is int id && id <= 0)
//         {
//             context.Result = new BadRequestObjectResult("Order id must be > 0.");
//             return;
//         }

//         _logger.LogInformation("Action start: {Action}", context.ActionDescriptor.DisplayName);
//         context.HttpContext.Items["LogFilter_Stopwatch"] = Stopwatch.StartNew();
//     }

//     public void OnActionExecuted(ActionExecutedContext context)
//     {
//         if (context.HttpContext.Items.TryGetValue("LogFilter_Stopwatch", out var swObj) && swObj is Stopwatch sw)
//         {
//             sw.Stop();
//             _logger.LogInformation("Action end: {Action} in {Ms}ms", context.ActionDescriptor.DisplayName, sw.ElapsedMilliseconds);
//         }
//         else
//         {
//             _logger.LogInformation("Action end: {Action}", context.ActionDescriptor.DisplayName);
//         }
//     }
// }


// Using IActionAsync

    public class LoggingActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;
        public LoggingActionFilter(ILogger<LoggingActionFilter> logger) => _logger = logger;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Simple input guard
            if (context.ActionArguments.TryGetValue("id", out var val) &&
                val is int id && id <= 0)
            {
                context.Result = new BadRequestObjectResult("Order id must be > 0.");
                return;
            }

            _logger.LogInformation("Action start: {Action}", context.ActionDescriptor.DisplayName);
            var sw = Stopwatch.StartNew();
            var resultContext = await next(); // Proceed to the action
            sw.Stop();
            _logger.LogInformation("Action end: {Action} in {Ms}ms", context.ActionDescriptor.DisplayName, sw.ElapsedMilliseconds);
        }

        // On executing and executed displaying only message
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Action executing: {Action}", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Action executed: {Action}", context.ActionDescriptor.DisplayName);
        }
    }
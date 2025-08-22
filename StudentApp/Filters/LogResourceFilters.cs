using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace StudentApp.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Logic before the action executes
            Debug.WriteLine("Incoming request..." + context.HttpContext.Request.Path);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Logic after the action executes
            Debug.WriteLine("Outgoing response..." + context.HttpContext.Response.StatusCode);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace StudentApp.Filters
{
    public class AppendMessageFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Logic before the result executes
            Debug.WriteLine("Appending message to response...");

            // Append a message to the response
            // if (context.Result is ObjectResult objectResult)
            // {
            //     objectResult.Value = $"{objectResult.Value} - Processed by AppendMessageFilter";
            // }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Logic after the result executes
            Debug.WriteLine("Response has been sent.");
            if (context.Result is ContentResult contentResult)
            {
                // Optionally, you can modify the response here
                contentResult.Content += " - Processed by AppendMessageFilter";
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log the exception
            Debug.WriteLine("Exception occurred: " + context.Exception.Message);

            // Return a custom error response
            context.Result = new ObjectResult("An error occurred while processing your request.")
            {
                StatusCode = 500
            };
        }
    }
}
//here we will create a class i.e ValidateStudentFilter class
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;


namespace StudentApp.Filters
{
    public class ValidateStudentFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Logic before the action executes
            Console.WriteLine("Incoming request..." + context.ActionDescriptor.DisplayName);

            // Checking Input from the user
            // Checking input from the user during the time action method executes
            if (context.ActionArguments.ContainsKey("student"))
            {
                var name = context.ActionArguments["name"] as string;
                if (string.IsNullOrEmpty(name))
                {
                    context.ModelState.AddModelError("name", "Name cannot be null or empty");
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logic after the action executes
            Console.WriteLine("Outgoing response..." + context.ActionDescriptor.DisplayName);
        }
    }
}
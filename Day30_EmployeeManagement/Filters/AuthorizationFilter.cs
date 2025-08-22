using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day30_EmployeeManagement.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Implement your authorization logic here
            {
        var role = context.HttpContext.Request.Headers["X-Role"].ToString();
        if (!string.Equals(role, "Manager", StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new ContentResult { StatusCode = 403, Content = "Forbidden: Manager role required." };
        }
    }
        }
    }
}
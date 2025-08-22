using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace StudentApp.Filters
{
    // This filter checks if the user is authorized before allowing access to the action    
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthorized = false; // Replace with actual authorization logic
            if (!isAuthorized)
            {
                context.Result = new ContentResult
                {
                    Content = "Unauthorized access",
                    StatusCode = 403 // Forbidden
                };
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Day29_ECommerce_assignment2.Services;

namespace Day29_ECommerce_assignment2.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        private readonly IAuthService _authService;

        public AuthenticationFilter(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_authService.IsUserLoggedIn())
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
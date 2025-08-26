using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day30_BookStoreAppAssignment.Filters
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToPageResult("/Auth/Login");
            }
        }
    }
}
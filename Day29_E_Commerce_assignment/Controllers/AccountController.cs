using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day29_E_Commerce_assignment.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string role = "User")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "demo"),
                new Claim(ClaimTypes.Role, role)
            };
            var id = new ClaimsIdentity(claims, "CookieAuth");
            var p = new ClaimsPrincipal(id);
            await HttpContext.SignInAsync("CookieAuth", p);

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day30_BookStoreAppAssignment.Models;

namespace Day30_BookStoreAppAssignment.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            var user = UserRepository.Validate(Email, Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return Page();
            }

            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role);

            return RedirectToPage("/Books/BookList");
        }

        public IActionResult OnGetLogout()
{
    HttpContext.Session.Clear();
    return RedirectToPage("/Auth/Login");
}

    }
}
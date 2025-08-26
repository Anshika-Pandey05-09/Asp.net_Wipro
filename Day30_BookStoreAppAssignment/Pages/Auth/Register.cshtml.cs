using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day30_BookStoreAppAssignment.Models;

namespace Day30_BookStoreAppAssignment.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserRepository.Register(NewUser);
            TempData["Message"] = "Registration successful! Please login.";
            return RedirectToPage("/Auth/Login");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day30_BookStoreAppAssignment.Models;
using Day30_BookStoreAppAssignment.Filters;

namespace Day30_BookStoreAppAssignment.Pages.Books
{
    [AdminAuthorize]
    public class CreateBookModel : PageModel
    {
        [BindProperty]
        public Book NewBook { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // redisplay form with validation errors
            }

            BookRepository.Add(NewBook);
            return RedirectToPage("/Books/BookList"); // after add, go to list page
        }
    }
}
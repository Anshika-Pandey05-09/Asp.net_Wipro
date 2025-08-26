using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day30_BookStoreAppAssignment.Models;

namespace Day30_BookStoreAppAssignment.Pages.Books
{
    public class EditBookModel : PageModel
    {
        [BindProperty]
        public Book EditBook { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = BookRepository.GetById(id);
            if (book == null)
            {
                return RedirectToPage("/Books/BookList");
            }

            EditBook = book;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            BookRepository.Update(EditBook);
            return RedirectToPage("/Books/BookList");
        }
    }
}
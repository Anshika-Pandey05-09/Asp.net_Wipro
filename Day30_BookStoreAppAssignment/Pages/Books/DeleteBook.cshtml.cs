using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Day30_BookStoreAppAssignment.Models;

namespace Day30_BookStoreAppAssignment.Pages.Books
{
    public class DeleteBookModel : PageModel
    {
        [BindProperty]
        public Book BookToDelete { get; set; }

        public IActionResult OnGet(int id)
        {
            var book = BookRepository.GetById(id);
            if (book == null)
            {
                return RedirectToPage("/Books/BookList");
            }

            BookToDelete = book;
            return Page();
        }

        public IActionResult OnPost()
        {
            BookRepository.Delete(BookToDelete.Id);
            return RedirectToPage("/Books/BookList");
        }
    }
}
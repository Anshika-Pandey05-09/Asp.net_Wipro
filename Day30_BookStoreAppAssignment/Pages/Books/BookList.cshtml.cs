using Microsoft.AspNetCore.Mvc.RazorPages;
using Day30_BookStoreAppAssignment.Models;
using System.Collections.Generic;

namespace Day30_BookStoreAppAssignment.Pages.Books
{
    public class BookListModel : PageModel
    {
        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = BookRepository.GetAll();
        }
    }
}
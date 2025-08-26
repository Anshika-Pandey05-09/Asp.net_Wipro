using Microsoft.AspNetCore.Mvc;
using Day30_BookStoreAppAssignment.Models;
using Day30_BookStoreAppAssignment.Filters;

namespace Day30_BookStoreAppAssignment.Controllers
{
    public class BooksController : Controller
    {
        // [AdminAuthorize]
        public IActionResult Index()
        {
            var books = BookRepository.GetAll();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = BookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}
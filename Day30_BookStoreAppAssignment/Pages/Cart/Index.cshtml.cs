using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Day30_BookStoreAppAssignment.Models;
using Day30_BookStoreAppAssignment.Helpers;
using System.Collections.Generic;
using System.Linq;
using Day30_BookStoreAppAssignment.Filters;

namespace Day30_BookStoreAppAssignment.Pages.Cart
{
    [SessionAuthorize]
    public class IndexModel : PageModel
    {
        public List<CartItem> Cart { get; set; } = new();

        public void OnGet()
        {
            Cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
        }

        public IActionResult OnPostAdd(int bookId)
        {
            var book = BookRepository.GetById(bookId);
            if (book == null) return RedirectToPage("/Books/BookList");

            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            var item = cart.FirstOrDefault(c => c.BookId == book.Id);
            if (item != null)
                item.Quantity++;
            else
                cart.Add(new CartItem { BookId = book.Id, Title = book.Title, Price = book.Price, Quantity = 1 });

            HttpContext.Session.SetObject("Cart", cart);

            return RedirectToPage();
        }

        public IActionResult OnPostRemove(int bookId)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            var item = cart.FirstOrDefault(c => c.BookId == bookId);
            if (item != null)
            {
                cart.Remove(item);
            }

            HttpContext.Session.SetObject("Cart", cart);

            return RedirectToPage();
        }
    }
}
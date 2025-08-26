using Microsoft.AspNetCore.Mvc;
using Day30_BookStoreAppAssignment.Models;
using Day30_BookStoreAppAssignment.Helpers;
using Day30_BookStoreAppAssignment.Filters;


namespace Day30_BookStoreAppAssignment.Controllers
{
    // [SessionAuthorize]
    public class OrderController : Controller
    {
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
            if (cart.Count == 0)
            {
                return RedirectToPage("/Cart/Index");
            }

            return View(cart);
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
            if (cart.Count == 0)
            {
                return RedirectToPage("/Cart/Index");
            }

            var email = HttpContext.Session.GetString("UserEmail") ?? "guest@bookstore.com";

            var order = new Order
            {
                UserEmail = email,
                Items = cart
            };

            OrderRepository.Add(order);

            HttpContext.Session.Remove("Cart"); // clear cart

            return RedirectToAction("Confirmation", new { id = order.Id });
        }

        public IActionResult Confirmation(int id)
        {
            var order = OrderRepository.GetById(id);
            if (order == null) return NotFound();

            return View(order);
        }
    }
}
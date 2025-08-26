using System;
using System.Collections.Generic;

namespace Day30_BookStoreAppAssignment.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<CartItem> Items { get; set; }
        public decimal Total => Items != null ? Items.Sum(i => i.Price * i.Quantity) : 0;
    }
}
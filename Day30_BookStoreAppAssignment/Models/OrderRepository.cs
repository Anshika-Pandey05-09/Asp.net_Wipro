using System.Collections.Generic;
using System.Linq;

namespace Day30_BookStoreAppAssignment.Models
{
    public static class OrderRepository
    {
        private static List<Order> orders = new List<Order>();

        public static void Add(Order order)
        {
            order.Id = orders.Count + 1;
            orders.Add(order);
        }

        public static List<Order> GetAll() => orders;

        public static Order GetById(int id) => orders.FirstOrDefault(o => o.Id == id);
    }
}
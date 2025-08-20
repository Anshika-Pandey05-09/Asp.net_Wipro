using System.Collections.Generic;

namespace Day27_Assignment1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        // Collection of categories
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
using System.ComponentModel.DataAnnotations;

namespace Day30_BookStoreAppAssignment.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "ISBN must be in format 000-0000000000")]
        public string ISBN { get; set; }

        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000")]
        public decimal Price { get; set; }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Day30_BookStoreAppAssignment.Models
{
    public static class BookRepository
    {
        private static List<Book> books = new List<Book>();

        public static List<Book> GetAll() => books;

        public static Book GetById(int id) => books.FirstOrDefault(b => b.Id == id);

        public static void Add(Book book)
        {
            book.Id = books.Count + 1;
            books.Add(book);
        }

        public static void Update(Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.ISBN = updatedBook.ISBN;
                book.Price = updatedBook.Price;
            }
        }

        public static void Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}
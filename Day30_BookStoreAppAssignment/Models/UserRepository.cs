using System.Collections.Generic;
using System.Linq;

namespace Day30_BookStoreAppAssignment.Models
{
    public static class UserRepository
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Email = "admin@bookstore.com", Password = "admin123", Role = "Admin" }
        };

        public static User Register(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return user;
        }

        public static User Validate(string email, string password)
        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
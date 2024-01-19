using BCrypt.Net;
using Praktik.API.Models;

namespace Praktik.API.Services
{
    public class DataService
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<User> Users { get; set; } = new List<User>(); 

        public DataService()
        {
            Users.Add(new User { Id = 1, Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin123") });
            Users.Add(new User { Id = 2, Username = "user", Password = BCrypt.Net.BCrypt.HashPassword("user123") });

            SeedBooks();
        }

        public void SeedBooks()
        {
            Books.Add(new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublishedYear = "1925" });
            Books.Add(new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublishedYear = "1960" });
            Books.Add(new Book { Id = 3, Title = "1984", Author = "George Orwell", PublishedYear = "1949" });
        }
    }
}
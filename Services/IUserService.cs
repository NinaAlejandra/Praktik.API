using BCrypt.Net;
using Praktik.API.Models;

namespace Praktik.API.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly DataService _dataService;

        public UserService(DataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _dataService.Users.SingleOrDefault(x => x.Username == username));

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                Console.WriteLine($"Password verification successful for user: {username}");
                return user;
            }
            else
            {
                Console.WriteLine($"Password verification failed for user: {username}");
            }

            return null;
        }
    }

}

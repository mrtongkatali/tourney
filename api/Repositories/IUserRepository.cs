using api.Dtos.Auth;
using tourney.Models;

namespace tourney.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user, string confirmPassword);
        Task<User> Authenticate(string email, string password);
        Task<List<User>> GetAllAsync();
        // Task<User> CreateUser(User user);
        // Task<User> UpdateUser(User user);
        // Task<User> DeleteUser(User user);
    }
}
using tourney.api.Models;

namespace tourney.api.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task Create(User user, string confirmPassword);
        Task<User?> Authenticate(string email, string password);
        Task<bool> CheckEmailUnique(string email);
        Task<List<User>> GetAllAsync();
    }
}
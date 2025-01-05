using Microsoft.EntityFrameworkCore;
using tourney.api.Data;
using tourney.api.Helpers;
using tourney.api.Models;

namespace tourney.api.Repositories
{
   public class UserRepository : IUserRepository 
   {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<User>(id);
        }

        public async Task<bool> CheckEmailUnique(string email)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);
            return user == null;
        }
        public async Task Create(User user, string confirmPassword)
        {
            user.Password = PasswordHelper.HashPassword(user.Password);

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> Authenticate(string email, string password)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !PasswordHelper.VerifyPassword(password, user.Password))
            {
                return null;
            }

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.User.ToListAsync();
        }
   } 
}
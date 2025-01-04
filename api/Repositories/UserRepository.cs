using System.Security.Claims;
using api.Dtos.Auth;
using api.Mappers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using tourney.Data;
using tourney.Helpers;
using tourney.Models;

namespace tourney.Repositories
{
   public class UserRepository : IUserRepository 
   {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(User user, string confirmPassword)
        {
            var existingUser = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            if (user.Password != confirmPassword)
            {
                throw new Exception("Password and Confirm Password do not match.");
            }

            user.Password = PasswordHelper.HashPassword(user.Password);

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !PasswordHelper.VerifyPassword(password, user.Password))
            {
                throw new Exception("Invalid email address or Password");
            }

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.User.ToListAsync();
        }
   } 
}
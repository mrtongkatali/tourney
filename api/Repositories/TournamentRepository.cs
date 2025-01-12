
using Microsoft.EntityFrameworkCore;
using tourney.api.Data;
using tourney.api.Models;

namespace tourney.api.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TournamentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tournament?> GetByIdAsync(int id, int userId)
        {
            return await _dbContext.Tournament.FirstOrDefaultAsync(u => u.Id == id && u.UserId == userId); 
        }

        public async Task Create(Tournament tournament)
        {
            await _dbContext.Tournament.AddAsync(tournament);
            await _dbContext.SaveChangesAsync();
        }
    }
}
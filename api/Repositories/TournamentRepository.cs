
using tourney.api.Data;
using tourney.api.Models;

namespace api.Repositories
{
    public class TournamentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TournamentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tournament?> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<Tournament>(id);
        }
    }
}
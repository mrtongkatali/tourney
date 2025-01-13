using tourney.api.Models;

namespace tourney.api.Repositories
{
    public interface ITournamentRepository
    {
        Task<Tournament?> GetByIdAsync(int id, int userId);
        Task Create(Tournament tournament);
        Task Update(Tournament tournament, int userId);
    }
}
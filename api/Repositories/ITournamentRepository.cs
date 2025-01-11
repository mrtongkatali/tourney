using tourney.api.Models;

namespace tourney.api.Repositories
{
    public interface ITournamentRepository
    {
        Task<Tournament> GetByIdAsync(int id);
        Task Create(Tournament tournament);
    }
}
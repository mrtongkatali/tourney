using tourney.api.Models;

namespace api.Repositories
{
    public interface ITournamentRepository
    {
        Task<Tournament> GetByIdAsync(int id);
        Task Create(Tournament tournament);
    }
}
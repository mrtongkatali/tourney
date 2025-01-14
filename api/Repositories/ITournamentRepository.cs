using tourney.api.Dtos.Tournament;
using tourney.api.Models;

namespace tourney.api.Repositories
{
    public interface ITournamentRepository
    {
        Task<Tournament?> GetByIdAsync(int id, int userId);
        Task Create(Tournament tournament);
        Task Update(PatchTournamentDto dto, int tournamentId, int userId);
    }
}

using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using tourney.api.Data;
using tourney.api.Dtos.Tournament;
using tourney.api.Helpers;
using tourney.api.Mappers;
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
            return await _dbContext.Tournament
                .Where(u => u.Id == id && u.UserId == userId)
                .Include(t => t.Teams)
                .FirstOrDefaultAsync();
        }

        public async Task Update(PatchTournamentDto dto, int tournamentId, int userId)
        {
            var oldModel = await GetByIdAsync(tournamentId, userId);

            if (oldModel == null) {
                throw new Exception("Tournament not found");
            }

            var config = new MapperConfiguration(cfg => cfg.AddProfile<TournamentProfile>());
            var mapper = config.CreateMapper();

            var updatedModel = mapper.Map(dto, oldModel);
            
            _dbContext.Tournament.Update(updatedModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Tournament tournament)
        {
            await _dbContext.Tournament.AddAsync(tournament);
            await _dbContext.SaveChangesAsync();
        }
    }
}
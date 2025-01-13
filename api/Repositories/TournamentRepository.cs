
using Microsoft.EntityFrameworkCore;
using tourney.api.Data;
using tourney.api.Mappers;
using tourney.api.Models;

namespace tourney.api.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DynamicMapper _dynamicMapper;
        private readonly ApplicationDbContext _dbContext;
        public TournamentRepository(DynamicMapper mapper, ApplicationDbContext dbContext)
        {
            _dynamicMapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Tournament?> GetByIdAsync(int id, int userId)
        {
            return await _dbContext.Tournament.FirstOrDefaultAsync(u => u.Id == id && u.UserId == userId); 
        }

        public async Task Update(Tournament tournament, int userId)
        {
            var oldModel = await GetByIdAsync(tournament.Id, userId);

            if (oldModel == null) {
                throw new Exception("Tournament not found");
            }

            // _dynamicMapper.Map(tournament, oldModel);

            // Console.WriteLine(JsonHelper.SerializeModel(oldModel));


            // _dbContext.Entry(oldModel).CurrentValues.SetValues(tournament);
            // await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Tournament tournament)
        {
            await _dbContext.Tournament.AddAsync(tournament);
            await _dbContext.SaveChangesAsync();
        }
    }
}
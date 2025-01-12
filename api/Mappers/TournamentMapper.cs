using tourney.api.Dtos.Tournament;
using tourney.api.Models;

namespace tourney.api.Mappers
{
    public static class TournamentMapper
    {
        public static Tournament toModel(this CreateTourneyDto dto)
        {
            return new Tournament
            {
                Name = dto.Name, 
                Description = dto.Description,
                TournamentType = dto.TournamentType
            };
        }
    }
}
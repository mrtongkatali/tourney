using tourney.api.Dtos.Tournament;
using tourney.api.Models;

namespace tourney.api.Mappers
{
    public static class TournamentMapper
    {
        public static TournamentDto AsPartialResponse(this Tournament tournamentModel)
        {
            return new TournamentDto
            {
                Id = tournamentModel.Id,
                UserId = tournamentModel.UserId,
                Name = tournamentModel.Name,
                Description = tournamentModel.Description,
                StartDate = tournamentModel.StartDate,
                EndDate = tournamentModel.EndDate,
                PrizePool = tournamentModel.PrizePool,
                PrizePoolCurrency = tournamentModel.PrizePoolCurrency,
                ParticipantSize = tournamentModel.ParticipantSize,
                Status = tournamentModel.Status,
                TournamentType = tournamentModel.TournamentType,
            };
        }
        public static Tournament ToModel(this CreatePatchTourneyDto dto)
        {
            return new Tournament
            {
                Name = dto.Name, 
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                PrizePool = dto.PrizePool,
                PrizePoolCurrency = dto.PrizePoolCurrency,
                ParticipantSize = dto.ParticipantSize,
                TournamentType = dto.TournamentType,
            };
        }
    }
}
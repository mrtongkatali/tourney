using tourney.api.Models;

namespace tourney.api.Dtos.Tournament
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal PrizePool { get; set; }
        public string PrizePoolCurrency { get; set; } = "USD";
        public int ParticipantSize { get; set; } = 0;
        public TournamentStatus Status { get; set; } = TournamentStatus.LIVE;
        public TournamentType TournamentType { get; set; } = TournamentType.HYBRID;
    }
}
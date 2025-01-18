using tourney.api.Models;

namespace tourney.api.Dtos.TournamentStage
{
    public class TournamentStageDto
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int StageOrder { get; set; }
        public string StageName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StageStatus Status { get; set; } = StageStatus.ACTIVE;
    }
}
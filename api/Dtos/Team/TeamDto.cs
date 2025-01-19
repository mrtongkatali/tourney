using tourney.api.Models;

namespace tourney.api.Dtos.Team
{
    public class TeamDto 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TeamStatus Status { get; set; }
    }
}
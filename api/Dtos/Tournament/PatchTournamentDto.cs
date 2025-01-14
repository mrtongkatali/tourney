using System.ComponentModel.DataAnnotations;

namespace tourney.api.Dtos.Tournament;
public class PatchTournamentDto 
{
    [Required(ErrorMessage = "Tournament name is required")]
    [StringLength(50, ErrorMessage = "Tournament name cannot exceed 50 characters")]
    public string? Name { get; set; }

    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal PrizePool { get; set; }
    public string? PrizePoolCurrency { get; set; } 
    public int ParticipantSize { get; set; }
}
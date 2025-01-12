using System.ComponentModel.DataAnnotations;
using tourney.api.Models;

namespace tourney.api.Dtos.Tournament;
public class CreatePatchTourneyDto 
{
    [Required(ErrorMessage = "Tournament name is required")]
    [StringLength(50, ErrorMessage = "Tournament name cannot exceed 50 characters")]
    public string Name { get; set; } = string.Empty;

    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
    public string Description { get; set; } = string.Empty;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal PrizePool { get; set; } = 0;
    public string PrizePoolCurrency { get; set; } = "USD";
    public int ParticipantSize { get; set; } = 0;

    [Required(ErrorMessage = "Tournament type is required")]
    [EnumDataType(typeof(TournamentType), ErrorMessage = "Invalid tournament type")]
    public TournamentType TournamentType { get; set; } = TournamentType.HYBRID;
}
using System.ComponentModel.DataAnnotations;
using tourney.api.Models;

namespace tourney.api.Dtos.Tournament;
public class CreateTourneyDto
{
    [Required(ErrorMessage = "Email is required")]
    [StringLength(50, ErrorMessage = "Tournament name cannot exceed 50 characters")]
    public string? Name { get; set; }

    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Tournament type is required")]
    [EnumDataType(typeof(TournamentType), ErrorMessage = "Invalid tournament type")]
    public TournamentType TournamentType { get; set; }
}
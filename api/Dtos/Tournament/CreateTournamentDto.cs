using System.ComponentModel.DataAnnotations;
using tourney.api.Models;

namespace tourney.api.Dtos.Tournament;
public class CreateTournamentDto : PatchTournamentDto
{
    [Required(ErrorMessage = "Tournament type is required")]
    [EnumDataType(typeof(TournamentType), ErrorMessage = "Invalid tournament type")]
    public TournamentType TournamentType { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourney.api.Models;

[Table("teams")]
public class Team : BaseEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("tournament_id")]
    public int tournamentId { get; set; }

    [Column("name", TypeName = "varchar(50)")]
    [Required(ErrorMessage = "Team name is required")]
    public string Name { get; set; } = string.Empty;
    public Tournament? Tournament { get; set; }
}
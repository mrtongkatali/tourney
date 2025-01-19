using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourney.api.Models;

public enum TeamStatus
{
    Active = 1,
    Inactive = 2,
}

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

    [Column("description", TypeName = "varchar(2000)")]
    public string Description { get; set; } = string.Empty;

    [Column("status")]
    public TeamStatus Status { get; set; } = TeamStatus.Active;
    public Tournament? Tournament { get; set; }
}
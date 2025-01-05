using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tourney.Models;

public enum Status
{
    [Description("Active")]
    ACTIVE = 1,

    [Description("Inactive")]
    INACTIVE = 2,
}

public enum TournamentType
{
    [Description("Hybrid")]
    HYBRID = 1,

    [Description("Knockout")]
    KNOCKOUT = 2,
}

namespace api.Models
{
    [Table("tournaments")]
    public class Tournament : BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("userId")]
        public int UserId { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Tournament name is required")]
        public string Name { get; set; } = string.Empty;

        [Column("description", TypeName = "varchar(255)")]
        public string Description { get; set; } = string.Empty;

        [Column("status")]
        public Status Status { get; set; } = Status.ACTIVE;

        [Column("tournamentType")]
        public TournamentType TournamentType { get; set; } = TournamentType.HYBRID;

        public User? User { get; set; }
    }
}
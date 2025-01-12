using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourney.api.Models;
public enum TournamentStatus 
{
    [Description("Live")]
    LIVE = 1,

    [Description("Draft")]
    PENDING = 2,
}
public enum TournamentType
{
    [Description("Hybrid")]
    HYBRID = 1,

    [Description("Knockout")]
    KNOCKOUT = 2,
}

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

    [Column("description", TypeName = "varchar(2000)")]
    public string Description { get; set; } = string.Empty;

    [Column("start_date")]
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [Column("end_date")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [Column("prize_pool", TypeName = "decimal(18, 2)")]
    public decimal PrizePool { get; set; }

    [Column("prize_pool_currency", TypeName = "varchar(3)")]
    public string PrizePoolCurrency { get; set; } = "USD";

    [Column("participant_size", TypeName = "int")]
    public int ParticipantSize { get; set; } = 0;

    [Column("status")]
    public TournamentStatus Status { get; set; } = TournamentStatus.LIVE;

    [Column("tournament_type")]
    public TournamentType TournamentType { get; set; } = TournamentType.HYBRID;

    public User? User { get; set; }
    public ICollection<Team> Teams { get; set; } = new List<Team>();
}
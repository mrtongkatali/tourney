using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace tourney.api.Models;
public enum StageStatus
{
    [Description("Archived")]
    ARCHIVED = 0,

    [Description("Active")]
    ACTIVE = 1,
}

public enum StageFormat
{
    [Description("Group Stage - Single Bracket")]
    GROUP_STAGE_SINGLE = 1,

    [Description("Group Stage - Double Bracket")]
    GROUP_STAGE_DOUBLE = 2,

    [Description("Group Stage - Triple Bracket")]
    GROUP_STAGE_TRIPLE = 3,

    [Description("Group Stage - Quadruple Bracket")]
    GROUP_STAGE_QUADRUPLE = 4,

    [Description("Single Elimination Bracket")]
    SINGLE_ELIMINATION = 5,

    [Description("Double Elimination Bracket")]
    DOUBLE_ELIMINATION = 6,
}

[Table("tournament_stages")]
public class TournamentStage : BaseEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("tournament_id")]
    public int TournamentId { get; set; }

    [Column("stage_order", TypeName = "int")]
    public int StageOrder { get; set; }

    [Column("stage_name", TypeName = "varchar(100)")]
    public string StageName { get; set; } = string.Empty;

    [Column("description", TypeName = "varchar(2000)")]
    public string Description { get; set; } = string.Empty;

    [Column("start_date")]
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [Column("end_date")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [Column("status")]
    public StageStatus Status { get; set; } = StageStatus.ACTIVE;

    [Column("stage_format")]
    public StageFormat StageFormat { get; set; } = StageFormat.GROUP_STAGE_DOUBLE;
    public Tournament? Tournament { get; set; }
}

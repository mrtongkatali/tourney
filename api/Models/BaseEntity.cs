using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourney.api.Models;

public abstract class BaseEntity 
{
    [Column("created_at")]
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    [DataType(DataType.Date)]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
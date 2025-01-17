using System.ComponentModel.DataAnnotations.Schema;

namespace tourney.api.Models
{
    [Table("user_profiles")]
    public class UserProfile : BaseEntity
    {
        public int Id { get; set; }

        public User? User { get; set; } // Navigation Property
        
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
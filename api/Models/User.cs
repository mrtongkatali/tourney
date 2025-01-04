using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models;

namespace tourney.Models;

public enum UserStatus 
{
    [Description("Active")]
    ACTIVE = 1,

    [Description("Inactive")]
    INACTIVE = 2,
}

[Table("users")]
public class User : BaseEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("email", TypeName = "varchar(100)")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    // [StringLength(2, ErrorMessage = "Name cannot exceed 2 characters.")]
    public string Email { get; set; } = string.Empty;

    [Column("password", TypeName = "varchar(100)")]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;

    [Column("first_name", TypeName = "varchar(50)")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name", TypeName = "varchar(50)")]
    public string LastName { get; set; } = string.Empty;

    [Column("status")]
    public UserStatus Status { get; set; } = UserStatus.ACTIVE;

    public UserProfile? UserProfile { get; set; } // Navigation Property
}
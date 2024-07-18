using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(800)]
        public string? RefreshToken { get; set; }
        [Required]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The password must be at least 3 characters long.")]
        public string Password { get; set; }

        public int Role { get; set; } // 1. Admin, 2. Supervisor, 3. Intern
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<Supervisor>? Supervisors { get; set; }
        public Intern? Intern { get; set; }

        [NotMapped]
        public string RoleName
        {
            get
            {
                return Role switch
                {
                    1 => "Admin",
                    2 => "Supervisor",
                    3 => "Intern",
                    _ => "Unknown"
                };
            }
        }
    }
}

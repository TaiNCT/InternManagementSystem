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

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(800)]
        public string RefreshToken { get; set; }

        [MaxLength(255)]

        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public int Role { get; set; } // 1. Admin, 2. Supervisor, 3. Intern
        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<Supervisor>? Supervisors { get; set; }
        public Intern Intern { get; set; }

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

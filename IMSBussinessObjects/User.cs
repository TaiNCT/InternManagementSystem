using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(800)]
        public string RefreshToken { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public int Role { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Supervisor> Supervisors { get; set; }
        public Intern Intern { get; set; }
    }
}

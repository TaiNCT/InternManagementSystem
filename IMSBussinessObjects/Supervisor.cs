using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Supervisors")]
    public class Supervisor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SupervisorId { get; set; }

        public long UserId { get; set; }
        public int TeamId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}
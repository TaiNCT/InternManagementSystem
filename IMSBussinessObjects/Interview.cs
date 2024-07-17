using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Interview")]
    public class Interview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterviewId { get; set; }

        public DateTime? InterviewDate { get; set; }

        [MaxLength(100)]
        public string? Location { get; set; }

        [MaxLength(20)]
        public string? RoomNumber { get; set; }

        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team? Team { get; set; }

        public int InternId { get; set; }

        [ForeignKey("InternId")]
        public Intern? Intern { get; set; }

        public int SupervisorId { get; set; } // Foreign key for Supervisor

        [ForeignKey("SupervisorId")]
        public Supervisor? Supervisor { get; set; }
    }
}

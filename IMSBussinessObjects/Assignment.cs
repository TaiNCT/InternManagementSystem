using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Assignments")]
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId { get; set; }

        public int? TeamId { get; set; }
        public int? InternId { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime? Deadline { get; set; }
        public int? Grade { get; set; }
        public int? Weight { get; set; }
        public bool Complete { get; set; }
        public int? DocumentId { get; set; }

        public string? Submited { get; set; }

        public string? Feedback { get; set; }

        [ForeignKey("DocumentId")]
        public Document? Documents { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        [ForeignKey("InternId")]
        public Intern Intern { get; set; }
    }
}
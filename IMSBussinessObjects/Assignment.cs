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

        public int? Deadline { get; set; }
        public int? Grade { get; set; }
        public int? Weight { get; set; }
        public bool Complete { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        [ForeignKey("InternId")]
        public Intern Intern { get; set; }
    }
}
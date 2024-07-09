using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Assignment")]
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public DateTime Deadline { get; set; }
        
        public int Weight { get; set; }

        public int Complete { get; set; }

        [ForeignKey("UserRole")]
        public int TeamId { get; set; }
      

       
    }
}

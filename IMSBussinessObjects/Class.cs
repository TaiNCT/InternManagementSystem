using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBussinessObjects
{
    [Table("Class")]
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ClassName { get; set; }
      


        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        [MaxLength(50)]
        public string Status { get; set; }

        public int InstructorId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set;}

        [ForeignKey("InstructorId")]
        public User Instructor { get; set; }


    }
}

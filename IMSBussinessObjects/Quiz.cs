using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBussinessObjects
{
    [Table("Quiz")]
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }

}

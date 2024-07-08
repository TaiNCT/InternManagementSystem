using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBussinessObjects
{
    [Table("InternSolution")]
    public class InternSolution
    {
        [Key, Column(Order = 0)]
        public int QuizId { get; set; }

        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Answer { get; set; }

        public int UserId { get; set; }

        [ForeignKey("QuizId, QuestionId")]
        public Question Question { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

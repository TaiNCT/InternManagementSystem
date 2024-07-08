using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBussinessObjects
{
    [Table("Question")]
    public class Question
    {
        [Key, Column(Order = 0)]
        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string QuesDes { get; set; }

        [Required]
        [MaxLength(255)]
        public string Answer { get; set; }
    }

}

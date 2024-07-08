using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBussinessObjects
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }

        public int TrainingUnitId { get; set; }
        [ForeignKey("TrainingUnitId")]
        public TrainingUnit TrainingUnit { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int MentorId { get; set; }
        [ForeignKey("MentorId")]
        public User Mentor { get; set; }

        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Comments { get; set; }
    }
}

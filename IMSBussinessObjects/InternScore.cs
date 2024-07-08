using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("InternScore")]
    public class InternScore
    {
        [Key, Column(Order = 0)]
        public int QuizId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Score { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

    }
}

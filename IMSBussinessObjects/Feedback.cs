using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects;

[Table("Feedbacks")]
public class Feedback
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackId { get; set; }

    public int CourseId { get; set; }
    public int UserId { get; set; }
    public int MentorId { get; set; }
    public int QuizId { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("MentorId")]
    public User Mentor { get; set; }

    [ForeignKey("QuizId")]
    public Quiz Quiz { get; set; }
}
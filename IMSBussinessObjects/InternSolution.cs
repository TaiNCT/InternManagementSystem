using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects;

[Table("InternSolutions")]
public class InternSolution
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SolutionId { get; set; }

    public int QuizId { get; set; }
    public int QuestionId { get; set; }
    public string Answer { get; set; }
    public int UserId { get; set; }

    [ForeignKey("QuizId")]
    public Quiz Quiz { get; set; }

    [ForeignKey("QuestionId")]
    public Question Question { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
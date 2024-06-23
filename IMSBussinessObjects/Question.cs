using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects;

[Table("Questions")]
public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int QuestionId { get; set; }

    public int QuizId { get; set; }

    public string QuesDes { get; set; }
    public string Answer { get; set; }

    [ForeignKey("QuizId")]
    public Quiz Quiz { get; set; }
}
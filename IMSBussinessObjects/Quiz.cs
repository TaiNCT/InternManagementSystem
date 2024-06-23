using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects;

[Table("Quizzes")]
public class Quiz
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int QuizId { get; set; }

    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }

    [StringLength(50)]
    public string Type { get; set; }

    [ForeignKey("CreatedBy")]
    public User CreatedUser { get; set; }
}
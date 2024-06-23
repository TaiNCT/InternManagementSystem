using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects;

[Table("TrainingUnits")]
public class TrainingUnit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UnitId { get; set; }

    public int CourseId { get; set; }

    [StringLength(255)]
    public string Name { get; set; }

    public int QuizId { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public float Grade { get; set; }

    [StringLength(50)]
    public string Status { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }

    [ForeignKey("QuizId")]
    public Quiz Quiz { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
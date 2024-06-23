using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects;

[Table("Courses")]
public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourseId { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int CreateBy { get; set; }
    public DateTime CreateDate { get; set; }
    public int UserId { get; set; }
    public float Percentage { get; set; }

    [ForeignKey("CreateBy")]
    public User CreateUser { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
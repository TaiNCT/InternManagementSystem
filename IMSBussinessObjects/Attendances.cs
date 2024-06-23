using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects;
[Table("Attendances")]
public class Attendance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AttendanceId { get; set; }

    public int UnitId { get; set; }
    public int UserId { get; set; }

    [StringLength(50)]
    public string Status { get; set; }

    public int MentorId { get; set; }

    [ForeignKey("UnitId")]
    public TrainingUnit Unit { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("MentorId")]
    public User Mentor { get; set; }
}
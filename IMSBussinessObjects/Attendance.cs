using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBussinessObjects
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }


        public int ClassId { get; set; }

        public int TraineeId { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }

        [ForeignKey("TraineeId")]
        public User Trainee { get; set; }
    }
}

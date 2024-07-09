using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NotificationId { get; set; }

        public int UserId { get; set; }
        public int? InternId { get; set; }
        public int NotificationDate { get; set; }
        public int TypeCode { get; set; }

        [MaxLength(250)]
        public string Content { get; set; }

        public int? Timestamp { get; set; }
        public bool IsSeen { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("InternId")]
        public Intern Intern { get; set; }
    }
}

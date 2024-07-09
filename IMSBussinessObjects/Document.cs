using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public DateTime NotificationDate { get; set; }
        
        public int TypeCode { get; set; }

        public int Timestamp { get; set; }

        public string Content { get; set; }
        
        public Boolean IsSeen { get; set; }


        [ForeignKey("UserRole")]
        public int TeamId { get; set; }
      

       
    }
}

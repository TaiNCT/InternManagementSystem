using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Supervisor")]
    public class Supervisor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(255)]
        public string? UserName { get; set; }

        [MaxLength(100)]
        public string? Password { get; set; }
        
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        
        [ForeignKey("UserRole")]
        public int RoleID { get; set; }
      

       
    }
}
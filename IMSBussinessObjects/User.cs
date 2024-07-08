using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(100)]
        public string Level { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public bool Status { get; set; }


        [ForeignKey("UserRole")]
        public int RoleId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Avatar { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        [Required]
        public string Level { get; set; }
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role? Role { get; set; }
    }
}

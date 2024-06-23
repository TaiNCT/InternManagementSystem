using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects;

[Table("Roles")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }

    [Required]
    [StringLength(255)]
    public string RoleName { get; set; }

    public ICollection<User> Users { get; set; }
    public ICollection<Permission> Permissions { get; set; }
}
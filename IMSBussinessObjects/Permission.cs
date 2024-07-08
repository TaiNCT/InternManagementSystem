using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBussinessObjects
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseAccess { get; set; }

 
        [Required]
        [StringLength(20)]
        public string UserAccess { get; set; }

        [Required]
        [StringLength(20)]
        public string ClassAccess { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual UserRole Role { get; set; }
    }
}

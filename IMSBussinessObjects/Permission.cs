using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects

{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        public int RoleId { get; set; }

        public bool CampaignsAccess { get; set; }
        public bool CourseAccess { get; set; }
        public bool UserAccess { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
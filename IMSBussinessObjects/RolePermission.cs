using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBussinessObjects
{
    public class RolePermission
    {
        [Key]
        public int PermissionId { get; set; }
        public string CampaignsAccess { get; set; }
        public string CourseAccess { get; set; }
        public string UserAccess { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}

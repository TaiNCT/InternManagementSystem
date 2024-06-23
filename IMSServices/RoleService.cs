using IMSBussinessObjects;
using IMSDaos;
using IMSRepositories;

namespace IMSServices
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository iRoleRepository = null;
        public RoleService()
        {
            if (iRoleRepository == null)
            {
                iRoleRepository = new RoleRepository();
            }
        }
        public Role GetRole(int roleID)
       => RoleDAO.Instance.GetRole(roleID);

        public List<Role> GetRoles()
        => RoleDAO.Instance.GetRoles();
    }
}

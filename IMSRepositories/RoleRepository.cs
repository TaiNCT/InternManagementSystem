using IMSBussinessObjects;
using IMSDaos;

namespace IMSRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleDAO roleDAO = null;
        public RoleRepository()
        {
            if (roleDAO == null)
            {
                roleDAO = new RoleDAO();
            }
        }
        public Role GetRole(int roleID)
        => RoleDAO.Instance.GetRole(roleID);

        public List<Role> GetRoles()
        => RoleDAO.Instance.GetRoles();
    }
}

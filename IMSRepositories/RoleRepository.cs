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
        public async Task<List<Role>> GetRolesAsync()
        => await RoleDAO.Instance.GetRolesAsync();

        Task<Role> IRoleRepository.GetRoleAsync(int roleID)
        => RoleDAO.Instance.GetRoleAsync(roleID);
    }
}

using IMSBussinessObjects;
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
        public Task<Role> GetRoleAsync(int roleID)
               => iRoleRepository.GetRoleAsync(roleID);

        public async Task<List<Role>> GetRolesAsync()
        => await iRoleRepository.GetRolesAsync();
    }
}

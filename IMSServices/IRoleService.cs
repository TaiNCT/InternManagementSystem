using IMSBussinessObjects;

namespace IMSServices
{
    public interface IRoleService
    {
        Task<Role> GetRoleAsync(int roleID);
        Task<List<Role>> GetRolesAsync();
    }
}

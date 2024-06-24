using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleAsync(int roleID);
        Task<List<Role>> GetRolesAsync();
    }
}

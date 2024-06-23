using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IRoleRepository
    {
        public Role GetRole(int roleID);
        public List<Role> GetRoles();

    }
}

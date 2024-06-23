using IMSBussinessObjects;

namespace IMSServices
{
    public interface IRoleService
    {
        public Role GetRole(int roleID);
        public List<Role> GetRoles();
    }
}

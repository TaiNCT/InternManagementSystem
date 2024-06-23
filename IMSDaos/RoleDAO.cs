using IMSBussinessObjects;

namespace IMSDaos
{

    public class RoleDAO
    {
        private readonly IMSDbContext db = null;
        private static RoleDAO instance = null;

        public RoleDAO()
        {
            db = new IMSDbContext();
        }
        public static RoleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoleDAO();
                }
                return instance;
            }
        }

        public Role GetRole(int roleID)
        {
            return db.Roles.FirstOrDefault(x => x.RoleId == roleID);
        }
        public List<Role> GetRoles()
        {
            return db.Roles.ToList();
        }

    }
}

using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Role> GetRoleAsync(int roleID)
        {
            return await db.Roles.FirstOrDefaultAsync(x => x.RoleId == roleID);
        }
        public async Task<List<Role>> GetRolesAsync()
        {
            return await db.Roles.ToListAsync();
        }


    }
}

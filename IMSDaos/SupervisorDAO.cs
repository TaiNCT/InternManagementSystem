using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDaos
{
    public class SupervisorDAO
    {
        private readonly AppDbContext db = null;
        private static SupervisorDAO instance=null;
        public SupervisorDAO()
        {
            db= new AppDbContext();
        }
        public static SupervisorDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SupervisorDAO();
                }
                return instance;
            }
        }
        public async Task<Supervisor> GetSupervisorByTeamIdAsync(int teamId)
        {
            return await db.Supervisors.FirstOrDefaultAsync(x => x.TeamId == teamId);
        }
    }
}

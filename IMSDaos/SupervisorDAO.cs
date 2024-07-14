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
        public Supervisor GetSupervisorById(int supId)
        {
            return db.Supervisors.FirstOrDefault(x => x.SupervisorId == supId);
        }
        public void UpdateSupervisor(int supId, Supervisor newSupervisor, User newUser, Team newTeam)
        {
            var existingSuperVisor = GetSupervisorById(supId);
            if (existingSuperVisor != null)
            {
                existingSuperVisor.UserId = newUser.UserId;
                existingSuperVisor.TeamId = newTeam.TeamId;

                db.Supervisors.Attach(existingSuperVisor);
                db.Entry(existingSuperVisor).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}

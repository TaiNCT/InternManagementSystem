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
        public void AddSupervisor(int UserId, Team newTeam)
        {
            Supervisor newSup = new Supervisor()
            {
                UserId = UserId,
                TeamId = newTeam.TeamId,
            };
            db.Add(newSup);
            db.SaveChanges();
        }
        public Supervisor GetSupervisorByUserId(int userId)
        {
            return db.Supervisors.FirstOrDefault(x => x.UserId == userId);
        }

        public void UpdateSupervisorTeam(int supervisorId, int teamId)
        {
            var existingSupervisor = db.Supervisors.FirstOrDefault(x => x.SupervisorId == supervisorId);
            if (existingSupervisor != null)
            {
                existingSupervisor.TeamId = teamId;
                db.Supervisors.Update(existingSupervisor);
                db.SaveChanges();
            }
        }

        public async Task UpdateSupervisorTeamAsync(int supervisorId, int teamId)
        {
            var supervisor = await db.Supervisors.FindAsync(supervisorId);
            if (supervisor != null)
            {
                supervisor.TeamId = teamId;
                db.Supervisors.Update(supervisor);
                await db.SaveChangesAsync();
            }
        }
    }
}

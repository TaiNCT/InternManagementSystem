using IMSBussinessObjects;
using IMSDaos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public class SupervisorRepository : ISupervisorRepository
    {
        public Supervisor GetSupervisorById(int supId) => SupervisorDAO.Instance.GetSupervisorById(supId);

        public async Task<Supervisor> GetSupervisorByTeamIdAsync(int teamId)
        {
            return await SupervisorDAO.Instance.GetSupervisorByTeamIdAsync(teamId);
        }

        public void AddSupervisor(int UserId, Team newTeam) => SupervisorDAO.Instance.AddSupervisor(UserId, newTeam);
        public Supervisor GetSupervisorByUserId(int userId)=>SupervisorDAO.Instance.GetSupervisorByUserId(userId);
        
    }
}

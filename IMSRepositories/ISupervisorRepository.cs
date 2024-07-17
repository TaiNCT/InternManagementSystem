using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public interface ISupervisorRepository
    {
        Task<Supervisor> GetSupervisorByTeamIdAsync(int teamId);
        public Supervisor GetSupervisorById(int supId);
        public void AddSupervisor(int UserId, Team newTeam);
        public Supervisor GetSupervisorByUserId(int userId);
        void UpdateSupervisorTeam(int supervisorId, int teamId);
        Task UpdateSupervisorTeamAsync(int supervisorId, int teamId);
    }
}

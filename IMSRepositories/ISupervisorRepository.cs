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
        List<Supervisor> GetSupervisorsByUserId(int userId);
    }
}

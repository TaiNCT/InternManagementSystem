using IMSBussinessObjects;
using IMSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public class SupervisorService : ISupervisorService
    {
        private readonly ISupervisorRepository _supervisorRepository;
        public SupervisorService(ISupervisorRepository supervisorRepository)
        {
            _supervisorRepository = supervisorRepository;
        }

        public Supervisor GetSupervisorById(int supId)
        {
            return _supervisorRepository.GetSupervisorById(supId);
        }

        public async Task<Supervisor> GetSupervisorByTeamIdAsync(int teamId)
        {
            return await _supervisorRepository.GetSupervisorByTeamIdAsync(teamId);
        }

        public void UpdateSupervisor(int supId, Supervisor newSupervisor, User newUser, Team newTeam)
        {
            _supervisorRepository.UpdateSupervisor(supId, newSupervisor, newUser, newTeam);
        }
    }
}

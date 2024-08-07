﻿using IMSBussinessObjects;
using IMSRepositories;

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

        public void AddSupervisor(int UserId, Team newTeam)
        {
            _supervisorRepository.AddSupervisor(UserId, newTeam);
        }
        public Supervisor GetSupervisorByUserId(int userId)
        {
            return _supervisorRepository.GetSupervisorByUserId(userId);
        }
        public void UpdateSupervisorTeam(int supervisorId, int teamId)
        {
            _supervisorRepository.UpdateSupervisorTeam(supervisorId, teamId);
        }
        public async Task UpdateSupervisorTeamAsync(int supervisorId, int teamId)
        {
            await _supervisorRepository.UpdateSupervisorTeamAsync(supervisorId, teamId);
        }


        public List<Supervisor> GetAllSupervisors()
        {
            return _supervisorRepository.GetAllSupervisors();
        }
    }
}

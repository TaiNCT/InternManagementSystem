﻿using IMSBussinessObjects;
using IMSDaos;

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
        public void UpdateSupervisorTeam(int supervisorId, int teamId) => SupervisorDAO.Instance.UpdateSupervisorTeam(supervisorId, teamId);
        public async Task UpdateSupervisorTeamAsync(int supervisorId, int teamId)
        {
            await SupervisorDAO.Instance.UpdateSupervisorTeamAsync(supervisorId, teamId);
        }
        public List<Supervisor> GetAllSupervisors()
        {
            return SupervisorDAO.Instance.GetAllSupervisors();
        }
    }
}

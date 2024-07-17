using IMSBussinessObjects;

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
        public List<Supervisor> GetAllSupervisors();


    }
}

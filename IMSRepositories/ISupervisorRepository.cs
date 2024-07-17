using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface ISupervisorRepository
    {
        Task<Supervisor> GetSupervisorByTeamIdAsync(int teamId);
        public Supervisor GetSupervisorById(int supId);
        public void AddSupervisor(int UserId, Team newTeam);
        public Supervisor GetSupervisorByUserId(int userId);
        public List<Supervisor> GetAllSupervisors();


    }
}

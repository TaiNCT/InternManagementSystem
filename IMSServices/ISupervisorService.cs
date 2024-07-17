using IMSBussinessObjects;

namespace IMSServices
{
    public interface ISupervisorService
    {
        Task<Supervisor> GetSupervisorByTeamIdAsync(int teamId);
        public Supervisor GetSupervisorById(int supId);
        public void AddSupervisor(int UserId, Team newTeam);
        public Supervisor GetSupervisorByUserId(int userId);
        public List<Supervisor> GetAllSupervisors();

    }
}

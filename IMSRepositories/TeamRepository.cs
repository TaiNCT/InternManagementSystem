using IMSBussinessObjects;
using IMSDaos;

namespace IMSRepositories
{
    public class TeamRepository : ITeamRepository
    {
        public void AddTeam(Team team) => TeamDAO.Instance.AddTeam(team);


        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await TeamDAO.Instance.GetAllTeamsAsync();
        }
        public List<Team> GetAllTeams()=> TeamDAO.Instance.GetAllTeams();

        public Team GetTeamById(int teamId)
        => TeamDAO.Instance.GetTeamById(teamId);

        public Team GetTeamByName(string teamName)
        => TeamDAO.Instance.GetTeamByName(teamName);

        public void RemoveTeam(int teamId)
        => TeamDAO.Instance.RemoveTeam(teamId);
        public async Task<Team> GetTeamByIdAsync(int teamId)
        {
            return await TeamDAO.Instance.GetTeamByIdAsync(teamId);
        }
        public void UpdateTeam(Team team) => TeamDAO.Instance.UpdateTeam(team);
        public async Task UpdateTeamAsync(Team team)
        {
            await TeamDAO.Instance.UpdateTeamAsync(team);
        }
    }
}

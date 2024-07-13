using IMSBussinessObjects;
using IMSDaos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamDAO teamDAO = null;

        public TeamRepository()
        {
            if (teamDAO == null)
            {
                teamDAO = new TeamDAO();
            }
        }
        public void AddTeam(Team team)=> TeamDAO.Instance.AddTeam(team);
        

        public List<Team> GetAllTeams()
        =>TeamDAO.Instance.GetAllTeams();

        public Team GetTeamById(int teamId)
        =>TeamDAO.Instance.GetTeamById(teamId);

        public Team GetTeamByName(string teamName)
        =>TeamDAO.Instance.GetTeamByName(teamName);

        public void RemoveTeam(int teamId)
        => TeamDAO.Instance.RemoveTeam(teamId);
    }
}

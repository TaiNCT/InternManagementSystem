using IMSBussinessObjects;
using IMSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public class TeamService : ITeamService
    {   
        private readonly ITeamRepository _TeamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            _TeamRepository = teamRepository;
        }

        public void AddTeam(Team team)
        {
            _TeamRepository.AddTeam(team);
        }

        public List<Team> GetAllTeams()
        {
            return _TeamRepository.GetAllTeams();
        }

        public Team GetTeamById(int teamId)
        {
            return _TeamRepository.GetTeamById(teamId);
        }

        public Team GetTeamByName(string teamName)
        {
            return _TeamRepository.GetTeamByName(teamName); 
        }

        public void RemoveTeam(int teamId)
        {
           _TeamRepository.RemoveTeam(teamId);
        }
    }
}

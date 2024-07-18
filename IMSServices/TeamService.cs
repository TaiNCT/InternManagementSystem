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
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public void AddTeam(Team team)
        {
            _teamRepository.AddTeam(team);
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _teamRepository.GetAllTeamsAsync();
        }

        public List<Team> GetAllTeams()
        {
            return _teamRepository.GetAllTeams();
        }
        public Team GetTeamById(int teamId)
        {
            return _teamRepository.GetTeamById(teamId);
        }

        public Team GetTeamByName(string teamName)
        {
            return _teamRepository.GetTeamByName(teamName);
        }

        public void RemoveTeam(int teamId)
        {
            _teamRepository.RemoveTeam(teamId);
        }
        public async Task<Team> GetTeamByIdAsync(int teamId)
        {
            return await _teamRepository.GetTeamByIdAsync(teamId);
        }
        public void UpdateTeam(Team team)
        {
            _teamRepository.UpdateTeam(team);
        }
        public async Task UpdateTeamAsync(Team team)
        {
            await _teamRepository.UpdateTeamAsync(team);
        }
    }
}

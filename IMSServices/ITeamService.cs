using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public interface ITeamService
    {
        public Team GetTeamById(int teamId);


        public Team GetTeamByName(string teamName);


        Task<List<Team>> GetAllTeamsAsync();
        public List<Team> GetAllTeams();


        public void AddTeam(Team team);


        public void RemoveTeam(int teamId);
        Task<Team> GetTeamByIdAsync(int teamId);
        void UpdateTeam(Team team);
        Task UpdateTeamAsync(Team team);
    }
}

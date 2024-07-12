using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public interface ITeamRepository
    {
        public Team GetTeamById(int teamId);


        public Team GetTeamByName(string teamName);


        public List<Team> GetAllTeams();


        public void AddTeam(Team team);


        public void RemoveTeam(int teamId);



    }
}

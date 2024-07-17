using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages
{
    [Authorize(Roles = "Supervisor,Admin")]
    public class IndexModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly IInternService _internService;
        private readonly IUserService _userService;
        private readonly ISupervisorService _supervisorService;

        public IndexModel(ITeamService teamService, IInternService internService, IUserService userService, ISupervisorService supervisorService)
        {
            _teamService = teamService;
            _internService = internService;
            _userService = userService;
            _supervisorService = supervisorService;
        }

        public IList<Team> Teams { get; set; }
        public Dictionary<string, int> InternCountByTeam { get; set; }
        public Dictionary<string, string> SupervisorByTeam { get; set; }
        public List<Intern> ApprovedInterns { get; set; }
     
    
        public async Task OnGetAsync()
        {
            Teams = await _teamService.GetAllTeamsAsync();
            ApprovedInterns = _internService.GetApprovedInterns();

            InternCountByTeam = new Dictionary<string, int>();
            SupervisorByTeam = new Dictionary<string, string>();

            foreach (var team in Teams)
            {
                var internCount = _internService.GetInternCountByTeamId(team.TeamId);
                InternCountByTeam[team.TeamName] = internCount;
                var supervisor = await _supervisorService.GetSupervisorByTeamIdAsync(team.TeamId);
                if (supervisor != null)
                {
                    var user = await _userService.GetUserBySupervisorIdAsync(supervisor.UserId);
                    if (user != null)
                    {
                        SupervisorByTeam[team.TeamName] = user.Username;
                    }
                    else
                    {
                        SupervisorByTeam[team.TeamName] = "No Supervisor";
                    }
                }
                else
                {
                    SupervisorByTeam[team.TeamName] = "No Supervisor";
                }
                Console.WriteLine($"Team: {team.TeamName}, SupervisorName: {SupervisorByTeam[team.TeamName]}");
            }

            ViewData["SupervisorByTeam"] = SupervisorByTeam;
            ViewData["ApprovedInterns"] = ApprovedInterns;
        }


    }
}


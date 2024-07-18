using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages
{
    [Authorize]
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
        public Dictionary<string, double> OverallSuccessByTeam { get; set; }
        public List<Intern> ApprovedInterns { get; set; }

        public async Task OnGetAsync()
        {
            Teams = await _teamService.GetAllTeamsAsync();
            ApprovedInterns = _internService.GetApprovedInterns();

            InternCountByTeam = new Dictionary<string, int>();
            SupervisorByTeam = new Dictionary<string, string>();
            OverallSuccessByTeam = new Dictionary<string, double>();

            foreach (var team in Teams)
            {
                var internCount = _internService.GetInternCountByTeamId(team.TeamId);
                InternCountByTeam[team.TeamName] = internCount;
                var supervisor = await _supervisorService.GetSupervisorByTeamIdAsync(team.TeamId);

                var internsInTeam = ApprovedInterns.Where(i => i.TeamId == team.TeamId).ToList();
                if (internsInTeam.Count > 0)
                {
                    var totalSuccess = internsInTeam.Where(i => i.OverallSuccess.HasValue).Sum(i => i.OverallSuccess.Value);
                    OverallSuccessByTeam[team.TeamName] = totalSuccess / internsInTeam.Count;
                }
                else
                {
                    OverallSuccessByTeam[team.TeamName] = 0;
                }

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
            ViewData["OverallSuccessByTeam"] = OverallSuccessByTeam;
        }

    }
}


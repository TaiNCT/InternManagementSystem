using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

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


        
        public async Task OnGetAsync()
        {
            // Lấy danh sách các đội
            Teams = await _teamService.GetAllTeamsAsync();

            // Khởi tạo các từ điển để lưu trữ số lượng thực tập sinh và giám sát viên
            InternCountByTeam = new Dictionary<string, int>();
            SupervisorByTeam = new Dictionary<string, string>();

            foreach (var team in Teams)
            {
                var internCount = _internService.GetInternCountByTeamId(team.TeamId);
                InternCountByTeam[team.TeamName] = internCount;
                // Lấy giám sát viên của đội
                var supervisor = await _supervisorService.GetSupervisorByTeamIdAsync(team.TeamId);
                if (supervisor != null)
                {
                    var user = await _userService.GetUserBySupervisorIdAsync(supervisor.UserId);
                    if (user != null)
                    {
                        // Lưu tên giám sát viên vào từ điển
                        SupervisorByTeam[team.TeamName] = user.Username;
                    }
                    else
                    {
                        SupervisorByTeam[team.TeamName] = "No User found for Supervisor";
                    }
                }
                else
                {
                    SupervisorByTeam[team.TeamName] = "No Supervisor";
                }
                Console.WriteLine($"Team: {team.TeamName}, SupervisorName: {SupervisorByTeam[team.TeamName]}");
            }

            // Đặt SupervisorByTeam vào ViewData để sử dụng trong Razor Page
            ViewData["SupervisorByTeam"] = SupervisorByTeam;
        }


    }
}


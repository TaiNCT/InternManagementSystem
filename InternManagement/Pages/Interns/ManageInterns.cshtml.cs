using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace InternManagement.Pages.Interns
{
    [Authorize(Roles = "Admin, Supervisor")]

    public class ManageInternModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly IInternService _internService;
        private readonly IAssignmentService _assignmentService;
        private readonly IUserService _userService;
        private readonly ISupervisorService _supervisorService;
        public ManageInternModel(ITeamService teamService, IInternService internService, IAssignmentService assignmentService, IUserService userService, ISupervisorService supervisorService)
        {
            _teamService = teamService;
            _internService = internService;
            _assignmentService = assignmentService;
            _userService = userService;
            _supervisorService = supervisorService;
        }

        [BindProperty(SupportsGet = true)]
        public int? TeamId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? InternId { get; set; }
        [BindProperty]
        public Assignment NewAssignment { get; set; }
        public List<SelectListItem> TeamsSelectList { get; set; }
        public List<SelectListItem> InternsSelectList { get; set; }

        public Team SelectedTeam { get; set; }

        public Intern SelectedIntern { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Intern> Interns { get; set; }
        public Supervisor supervisor { get; set; }

        public void OnGet()
        {
            var userEmailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = _userService.GetUsers().SingleOrDefault(x => x.Email == userEmailClaim);

            // Get list of all teams
            TeamsSelectList = _teamService.GetAllTeams()
                .Select(t => new SelectListItem
                {
                    Value = t.TeamId.ToString(),
                    Text = t.TeamName
                })
                .ToList();

            if (user != null)
            {
                var supervisor = _supervisorService.GetSupervisorByUserId(user.UserId);

                if (supervisor != null)
                {
                    // Check if TeamId is specified, otherwise default to supervisor's team
                    if (!TeamId.HasValue)
                    {
                        TeamId = supervisor.TeamId;
                    }

                    // Get the selected team
                    SelectedTeam = _teamService.GetTeamById(TeamId.Value);

                    if (SelectedTeam != null)
                    {
                        // Fetch interns for the selected team
                        Interns = _internService.GetApprovedInternsByTeamId(TeamId.Value).ToList();
                        InternsSelectList = Interns
                            .Select(i => new SelectListItem
                            {
                                Value = i.InternId.ToString(),
                                Text = i.FullName
                            })
                            .ToList();
                    }
                    else
                    {
                        // Handle case where SelectedTeam is null (e.g., team not found)
                    }
                }
                else
                {
                    // Handle case where supervisor is null (e.g., user is not a supervisor)
                }
            }

            if (InternId.HasValue)
            {
                SelectedIntern = _internService.GetInternById(InternId.Value);
                Assignments = _assignmentService.GetAssignmentByInternId(InternId.Value);
            }
        }


        public IActionResult OnPostDelete(int id)
        {
            var intern = _internService.GetInternById(id);
            if (intern != null)
            {
                _internService.RemoveIntern(id);
            }
            return RedirectToPage();
        }
    }
}

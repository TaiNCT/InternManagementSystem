using IMSBussinessObjects;
using IMSRepositories;
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
        public int Team { get; set; }

        public Intern SelectedIntern { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Intern> Interns { get; set; }
        [BindProperty]
        public Supervisor supervisor { get; set; }

        public void OnGet()
        {
            var userEmailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = _userService.GetUsers().SingleOrDefault(x => x.Email == userEmailClaim);
            if (user != null)
            {
                var Supervisor = _supervisorService.GetSupervisorByUserId(user.UserId);

                if (Supervisor != null)
                {
                    SelectedTeam = _teamService.GetTeamById(supervisor.TeamId);

                    if (SelectedTeam != null)
                    {
                        TeamId = Supervisor.TeamId; // Assign TeamId if needed

                        Interns = _internService.GetApprovedInternsByTeamId(TeamId.Value).ToList();
                        InternsSelectList = Interns
                            .Select(i => new SelectListItem
                            {
                                Value = i.InternId.ToString(),
                                Text = i.FullName
                            })
                            .ToList();
                    }
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

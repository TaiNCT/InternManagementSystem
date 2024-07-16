using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.Interns
{
    [Authorize(Roles = "Admin")]

    public class ManageInternModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly IInternService _internService;
        private readonly IAssignmentService _assignmentService;
        public ManageInternModel(ITeamService teamService, IInternService internService, IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
            _teamService = teamService;
            _internService = internService;
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

        public void OnGet()
        {
            TeamsSelectList = _teamService.GetAllTeams()
                .Select(t => new SelectListItem
                {
                    Value = t.TeamId.ToString(),
                    Text = t.TeamName
                })
                .ToList();
            if (TeamId.HasValue)
            {
                SelectedTeam = _teamService.GetTeamById(TeamId.Value);
                Interns = _internService.GetApprovedInternsByTeamId(TeamId.Value).ToList();
                InternsSelectList = Interns
                    .Select(i => new SelectListItem
                    {
                        Value = i.InternId.ToString(),
                        Text = i.FullName
                    })
                    .ToList();
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
using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.Assignments
{
    [Authorize(Roles = "Supervisor")]
    public class AssignmentManagementModel : PageModel
    {

        private readonly IAssignmentService _assignmentService;
        private readonly ITeamService _teamService;
        private readonly IInternService _internService;

        public AssignmentManagementModel(IAssignmentService assignmentService, ITeamService teamService, IInternService internService)
        {
            _assignmentService = assignmentService;
            _teamService = teamService;
            _internService = internService;
        }

        [BindProperty]
        public Assignment Assignment { get; set; } = new Assignment();
        public IList<Assignment> Assignments { get; set; } = new List<Assignment>();
        public SelectList Teams { get; set; }

        public async Task OnGetAsync()
        {
            Assignments = await _assignmentService.GetAssignmentsAsync();
            Teams = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
        }
        public async Task<IActionResult> OnPostCreateAssignmentAsync()
        {
           /* if (!ModelState.IsValid)
            {
                return Page();
            }
*/
            try
            {
                // Ensure Assignment.TeamId is assigned and convert from int? to int if needed
                int teamId = Assignment.TeamId ?? throw new InvalidOperationException("TeamId cannot be null");

                // Get all approved interns for the selected teamId
                var interns = await _internService.GetApprovedInternsByTeamIdAsync(teamId);

                // Create assignments for each intern
                foreach (var intern in interns)
                {
                    var newAssignment = new Assignment
                    {
                        TeamId = teamId,
                        InternId = intern.InternId,
                        Description = Assignment.Description,
                        Deadline = Assignment.Deadline,
                        Grade = Assignment.Grade,
                        Weight = Assignment.Weight,
                        Complete = Assignment.Complete
                    };
                    await _assignmentService.AddAssignmentAsync(newAssignment);
                }

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the assignment. Please try again.");
                return Page();
            }
        }

    }
}

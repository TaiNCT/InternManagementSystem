using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Assignments
{
    [Authorize(Roles = "Supervisor")]
    public class DeleteModel : PageModel
    {
        private readonly IAssignmentService _assignmentService;
        private readonly ITeamService _teamService;
        private readonly IInternService _internService;

        public DeleteModel(
            IAssignmentService assignmentService,
            ITeamService teamService,
            IInternService internService)
        {
            _assignmentService = assignmentService;
            _teamService = teamService;
            _internService = internService;
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        [BindProperty]
        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Assignment = await _assignmentService.GetAssignmentByIdAsync(id);

            if (Assignment == null)
            {
                return NotFound();
            }

            // Retrieve the team details associated with the assignment
            Team = await _teamService.GetTeamByIdAsync(Assignment.TeamId.Value);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var assignmentToRemove = await _assignmentService.GetAssignmentByIdAsync(id);

            if (assignmentToRemove == null)
            {
                return NotFound();
            }

            // Ensure Assignment.TeamId is not null before using it
            if (assignmentToRemove.TeamId.HasValue)
            {
                // Get all interns in the team
                var internsInTeam = await _internService.GetApprovedInternsByTeamIdAsync(assignmentToRemove.TeamId.Value);

                // Remove assignment for each intern
                foreach (var intern in internsInTeam)
                {
                    await _assignmentService.RemoveAssignmentAsync(id);
                }
            }
            else
            {
                // Handle the case where Assignment.TeamId is null (if needed)
            }

            return RedirectToPage("./AssignmentManagement");
        }
    }
}

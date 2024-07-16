using IMSBussinessObjects;
using IMSRepositories;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace InternManagement.Pages.Assignments
{
        [Authorize(Roles = "Supervisor")]
    public class GradeModel : PageModel
    {

        private readonly IAssignmentService _assignmentService;
        private readonly ITeamService _teamService;
        private readonly IInternService _internService;

        public GradeModel(
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

            // Check if Assignment.TeamId has a value before using it
            if (Assignment.TeamId.HasValue)
            {
                Team = await _teamService.GetTeamByIdAsync(Assignment.TeamId.Value);
            }
            else
            {
                // Handle the case where Assignment.TeamId is null (if needed)
                // For example, set a default Team or handle it based on your application logic
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var assignmentToUpdate = await _assignmentService.GetAssignmentByIdAsync(id);

            if (assignmentToUpdate == null)
            {
                return NotFound();
            }

            // Update only the Grade and Complete properties
            assignmentToUpdate.Grade = Assignment.Grade;
            assignmentToUpdate.Feedback = Assignment.Feedback;
            assignmentToUpdate.Complete = Assignment.Complete;

            // Save the changes
            await _assignmentService.UpdateAssignmentAsync(id,assignmentToUpdate);

            return RedirectToPage("./AssignmentManagement");
        }

    }
}

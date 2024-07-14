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

    public class EditModel : PageModel
    {
        private readonly IAssignmentService _assignmentService;
        private readonly ITeamService _teamService;
        private readonly IInternService _internService;

        public EditModel(
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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var assignmentToUpdate = await _assignmentService.GetAssignmentByIdAsync(id);

            if (assignmentToUpdate == null)
            {
                return NotFound();
            }

            assignmentToUpdate.Description = Assignment.Description;
            assignmentToUpdate.Deadline = Assignment.Deadline;
            assignmentToUpdate.Grade = Assignment.Grade;
            assignmentToUpdate.Weight = Assignment.Weight;
            assignmentToUpdate.Complete = Assignment.Complete;

            // Ensure Assignment.TeamId is not null before using it
            if (Assignment.TeamId.HasValue)
            {
                // Get all interns in the team
                var internsInTeam = await _internService.GetApprovedInternsByTeamIdAsync(Assignment.TeamId.Value);

                // Update assignments for each intern
                foreach (var intern in internsInTeam)
                {
                    // You may need to modify this based on your application's logic
                    await _assignmentService.UpdateAssignmentAsync(id, assignmentToUpdate, Team, intern);
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

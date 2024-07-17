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
        public List<Assignment> assignments { get; set; }

        [BindProperty]
        public Team Team { get; set; }

        [BindProperty]
        public Intern SelectedIntern { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Assignment = await _assignmentService.GetAssignmentByIdAsync(id);

            if (Assignment == null)
            {
                return NotFound();
            }

            if (!Assignment.InternId.HasValue)
            {
                // Handle the case where InternId is null or handle it based on your application logic
                // For example, redirect to an error page or handle it gracefully.
                return NotFound();
            }

            if (Assignment.TeamId.HasValue)
            {
                Team = await _teamService.GetTeamByIdAsync(Assignment.TeamId.Value);
            }

            SelectedIntern = await _internService.GetInternByIdAsync(Assignment.InternId.Value);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            var assignmentToUpdate = await _assignmentService.GetAssignmentByIdAsync(id);

            if (assignmentToUpdate == null)
            {
                return NotFound();
            }

            assignmentToUpdate.Grade = Assignment.Grade;
            assignmentToUpdate.Feedback = Assignment.Feedback;
            assignmentToUpdate.Complete = true;

            await _assignmentService.UpdateAssignmentAsync(id, assignmentToUpdate);

            if (!assignmentToUpdate.InternId.HasValue)
            {
                return NotFound();
            }

            assignments = _assignmentService.GetAssignmentByInternId(assignmentToUpdate.InternId.Value);

            CalculateOverallSuccess();

            await _internService.UpdateInternAsync(SelectedIntern.InternId, SelectedIntern);
            return RedirectToPage("../Interns/GradeInterns", new { internId = assignmentToUpdate.InternId, handler = "Details" });
        }

        private void CalculateOverallSuccess()
        {
            double totalWeightedGrade = 0;
            double totalWeight = 0;

            foreach (var assignment in assignments)
            {
                if (assignment.Grade.HasValue && assignment.Weight.HasValue)
                {
                    totalWeightedGrade += assignment.Grade.Value * (assignment.Weight.Value / 100.0);
                    totalWeight += assignment.Weight.Value;
                }
            }

            if (totalWeight > 0)
            {
                SelectedIntern.OverallSuccess = (int)(totalWeightedGrade / totalWeight * 100);
            }
            else
            {
                SelectedIntern.OverallSuccess = 0;
            }
        }
    }

}

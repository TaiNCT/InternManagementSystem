using IMSBussinessObjects;
using IMSRepositories;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace InternManagement.Pages.Interns
{
        [Authorize(Roles = "Intern")]
    public class  SubmitModel: PageModel
    {

        private readonly IAssignmentService _assignmentService;
        private readonly ITeamService _teamService;
        private readonly IInternService _internService;
        private readonly IDocumentsService documentsService;

        public SubmitModel(
            IAssignmentService assignmentService,
            ITeamService teamService,
            IInternService internService,
            IDocumentsService documentsSer)
        {
            _assignmentService = assignmentService;
            _teamService = teamService;
            _internService = internService;
            documentsService=documentsSer;
        }
        [BindProperty]
        public Assignment Assignment { get; set; }

        [BindProperty]
        public Team Team { get; set; }
        [BindProperty]
        public IFormFile DocumentFile { get; set; }

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
            if(DocumentFile!=null)
            {
                documentsService.UploadDocumentAsync(DocumentFile, 1);
            }

            // Update only the Grade and Complete properties
            assignmentToUpdate.Submited = Assignment.Submited;
            assignmentToUpdate.Complete =true;

            // Save the changes
            await _assignmentService.UpdateAssignmentAsync(id,assignmentToUpdate);

            return RedirectToPage("./InternProfile");
        }

    }
}

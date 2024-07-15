using IMSBussinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Assignments
{
    [Authorize(Roles = "Supervisor")]
    public class AssignmentManagementModel : PageModel
    {
        [BindProperty]
        public Assignment Assignment { get; set; } = new Assignment();
        public IList<Assignment> Assignments { get; set; } = new List<Assignment>();

        public void OnGet()
        {
        }
    }
}

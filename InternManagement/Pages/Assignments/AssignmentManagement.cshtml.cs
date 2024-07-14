using IMSBussinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Assignments
{
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

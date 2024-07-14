using IMSBussinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Assignments
{
    [Authorize(Roles = "Supervisor")]
    public class DeleteModel : PageModel
    {

        public Assignment Assignment { get; set; } = default!;

        public void OnGet()
        {
        }
    }
}

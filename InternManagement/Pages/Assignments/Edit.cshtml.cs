using IMSBussinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Assignments
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Assignment Assignment { get; set; } = default!;
        public void OnGet()
        {
        }
    }
}

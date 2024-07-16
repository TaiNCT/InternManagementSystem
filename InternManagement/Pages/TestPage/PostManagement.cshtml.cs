using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.TestPage
{
    [AllowAnonymous]
    public class PostManagementModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

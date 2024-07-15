using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages
{
    public class HomePageModel : PageModel
    {
        [AllowAnonymous]
        public void OnGet()
        {
        }
    }
}

using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Users
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IUserService userService;

        public DetailsModel(IUserService userServ)
        {
            userService = userServ;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || userService.GetUsers() == null)
            {
                return NotFound();
            }

            var user = userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }
    }
}

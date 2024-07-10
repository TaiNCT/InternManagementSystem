using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Users
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IUserService userService;

        public DeleteModel(IUserService userServ)
        {
            userService = userServ;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || userService.GetUsers() == null)
            {
                return NotFound();
            }
            userService.RemoveUser(id);

            return RedirectToPage("./Index");
        }
    }
}

using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.UserPage
{
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
            if (id == null || await userService.GetUsersAsync() == null)
            {
                return NotFound();
            }

            var user = await userService.GetUserAsync(id);

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
            if (id == null || await userService.GetUsersAsync() == null)
            {
                return NotFound();
            }
            await userService.DeleteUserAsync(id);

            return RedirectToPage("./Index");
        }
    }
}

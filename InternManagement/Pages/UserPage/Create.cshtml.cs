using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.UserPage
{
    public class CreateModel : PageModel
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public CreateModel(IUserService userServ, IRoleService roleServ)
        {
            userService = userServ;
            roleService = roleServ;
        }

        [BindProperty]
        public User User { get; set; } = new User();

        public SelectList Roles { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var roles = await roleService.GetRolesAsync();
            Roles = new SelectList(roles, "RoleId", "RoleName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await userService.AddUserAsync(User);

            return RedirectToPage("./Index");
        }
    }
}

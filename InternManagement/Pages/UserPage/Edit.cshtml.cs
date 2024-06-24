using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.UserPage
{
    public class EditModel : PageModel
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public EditModel(IUserService userServ, IRoleService roleServ)
        {
            userService = userServ;
            roleService = roleServ;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public SelectList Roles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0 || await userService.GetUsersAsync() == null)
            {
                return NotFound();
            }

            var user = await userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            User = user;
            Roles = new SelectList(await roleService.GetRolesAsync(), "RoleId", "RoleName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Roles = new SelectList(await roleService.GetRolesAsync(), "RoleId", "RoleName");
                return Page();
            }

            try
            {
                await userService.UpdateUserAsync(User.UserId, User);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                Roles = new SelectList(await roleService.GetRolesAsync(), "RoleId", "RoleName");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

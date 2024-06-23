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

        public IActionResult OnGet(int id)
        {
            if (id == 0 || userService.GetUsers() == null)
            {
                return NotFound();
            }

            var user = userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            User = user;
            Roles = new SelectList(roleService.GetRoles(), "RoleId", "RoleName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Roles = new SelectList(roleService.GetRoles(), "RoleId", "RoleName");
                return Page();
            }

            try
            {
                userService.UpdateUser(User.UserId, User);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                Roles = new SelectList(roleService.GetRoles(), "RoleId", "RoleName");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}

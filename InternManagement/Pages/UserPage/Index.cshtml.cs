using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.UserPage
{
    public class IndexModel : PageModel
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public IndexModel(IUserService userServ, IRoleService roleServ)
        {
            userService = userServ;
            roleService = roleServ;
        }

        public IList<User> User { get; set; } = default!;
        public SelectList Roles { get; set; } = default!;

        public async Task OnGetAsync()
        {
            User = await userService.GetUsersAsync();
            Roles = new SelectList(await roleService.GetRolesAsync(), "RoleId", "RoleName");
        }
    }
}

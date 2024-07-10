using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserService userService;

        public EditModel(IUserService userServ)
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
            User = user;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            userService.UpdateUser(User.UserId, User);

            return RedirectToPage("./Index");
        }


    }
}

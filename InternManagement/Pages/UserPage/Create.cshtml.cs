using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.UserPage
{
    public class CreateModel : PageModel
    {
        private readonly IUserService userService;

        public CreateModel(IUserService userServ)
        {
            userService = userServ;
        }

        [BindProperty]
        public User User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || userService.GetUsers() == null || User == null)
            {
                return Page();
            }

            userService.AddUser(User);

            return RedirectToPage("./Index");
        }
    }
}

using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserService userService;

        public CreateModel(IUserService userServ)
        {
            userService = userServ;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (User == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid user data.");
                return Page();
            }

            // You may need to call a method that sets the RefreshToken for User
            EnsureUserHasRefreshToken(User);

            if (!ModelState.IsValid || userService.GetUsers() == null)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            userService.AddUser(User);

            return RedirectToPage("./Index");
        }

        // Example method to ensure RefreshToken is set
        private void EnsureUserHasRefreshToken(User user)
        {
            if (string.IsNullOrEmpty(user.RefreshToken))
            {
                // Generate and set a new RefreshToken
                user.RefreshToken = GenerateNewRefreshToken();
            }
        }

        private string GenerateNewRefreshToken()
        {
            // Logic to generate a new refresh token
            return "generated_refresh_token";
        }
    }
}

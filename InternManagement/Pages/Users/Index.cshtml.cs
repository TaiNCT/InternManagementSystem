using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class UserManagementModel : PageModel
    {
        private readonly IUserService userService;
        private readonly ITeamService teamService;


        public UserManagementModel(IUserService userServ, ITeamService teamServ)
        {
            userService = userServ;
            teamService = teamServ;
        }

        [BindProperty]
        public User User { get; set; } = new User();

        [BindProperty]
        public Team Team { get; set; } = new Team();

        public IList<User> Users { get; set; } = new List<User>();
        public IList<Team> Teams { get; set; } = new List<Team>();

        public async Task OnGetAsync()
        {
            try
            {
                Users = userService.GetUsers();
                Teams = teamService.GetAllTeams();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error retrieving users: {ex.Message}");
            }
        }

        public async Task<IActionResult> OnPostCreateUserAsync()
        {
            if (User == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid user data.");
                return Page();
            }

            EnsureUserHasRefreshToken(User);

            if (!ModelState.IsValid)
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

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCreateTeamAsync()
        {
            if (Team == null || string.IsNullOrWhiteSpace(Team.TeamName))
            {
                ModelState.AddModelError(string.Empty, "Team Name is required.");
                return Page();
            }

            try
            {
                teamService.AddTeam(Team);
                return RedirectToPage("./Index"); // Redirect to the team list page
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while creating the team: {ex.Message}");
                return Page();
            }
        }



        private void EnsureUserHasRefreshToken(User user)
        {
            if (string.IsNullOrEmpty(user.RefreshToken))
            {
                user.RefreshToken = GenerateNewRefreshToken();
            }
        }

        private string GenerateNewRefreshToken()
        {
            return "generated_refresh_token";
        }
    }
}

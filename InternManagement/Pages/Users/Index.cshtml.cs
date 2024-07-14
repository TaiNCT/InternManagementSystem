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
                ModelState.AddModelError(string.Empty, $"Error retrieving data: {ex.Message}");
            }
        }

        public async Task<IActionResult> OnPostCreateUserAsync()
        {


            try
            {
                EnsureUserHasRefreshToken(User);
                userService.AddUser(User);
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while creating the user: {ex.Message}");
                Teams = teamService.GetAllTeams();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostCreateTeamAsync()
        {
            try
            {
                teamService.AddTeam(Team);
                return RedirectToPage();
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
            return Guid.NewGuid().ToString();
        }
    }
}
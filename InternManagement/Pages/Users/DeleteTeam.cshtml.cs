using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class DeleteTeamModel : PageModel
    {
        private readonly ITeamService teamService;
        public DeleteTeamModel(ITeamService teamServ)
        {
            teamService = teamServ;
        }
        [BindProperty]
        public Team Team { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || teamService.GetAllTeams() == null)
            {
                return NotFound();
            }

            var team = teamService.GetTeamById(id);

            if (team == null)
            {
                return NotFound();
            }
            else
            {
                Team = team;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || teamService.GetAllTeams() == null)
            {
                return NotFound();
            }
            teamService.RemoveTeam(id);

            return RedirectToPage("./Index");
        }
    }
}

using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class EditTeamModel : PageModel
    {
        private readonly IUserService userService;
        private readonly ITeamService teamService;
        private readonly ISupervisorService supervisorService;

        public EditTeamModel(IUserService userServ, ITeamService teamServ, ISupervisorService superService)
        {
            userService = userServ;
            teamService = teamServ;
            supervisorService = superService;
        }

        [BindProperty]
        public Team Team { get; set; }

        public IList<SelectListItem> SupervisorSelectList { get; set; }
        public int TeamId { get; set; }
        [BindProperty]
        public int SupervisorId { get; set; }


        public async Task OnGetAsync(int id)
        {
            Team = await teamService.GetTeamByIdAsync(id);
            TeamId = Team.TeamId;

            SupervisorSelectList = userService.GetUsers()
                .Where(x => x.Role == 2)
                .Select(t => new SelectListItem
                {
                    Value = t.UserId.ToString(),
                    Text = t.Username,
                })
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
             

                await teamService.UpdateTeamAsync(Team);
                await supervisorService.UpdateSupervisorTeamAsync(SupervisorId, Team.TeamId);
                return RedirectToPage("./Index");
            }
           
        }
    
}

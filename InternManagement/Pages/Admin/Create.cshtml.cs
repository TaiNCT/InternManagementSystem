using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace InternManagement.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ICampaignService campaignService;
        private readonly ITeamService _teamService;
        private readonly IUserService userService;
        public CreateModel(ICampaignService campaignSer, ITeamService teamService, IUserService userSer)
        {
            campaignService = campaignSer;
            _teamService = teamService;
            userService = userSer;
        }

        public IActionResult OnGet()
        {
            List<Team> teams = _teamService.GetAllTeams();
            TeamList = new SelectList(teams, nameof(Team.TeamId), nameof(Team.TeamName));
            return Page();
        }

        [BindProperty]
        public Campaign Campaign { get; set; } = default!;
        public SelectList TeamList { get; set; }
        [BindProperty]
        public IFormFile PictureURL { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                string? userEmailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
                User? user = userService.GetUsers().SingleOrDefault(x => x.Email.Equals(userEmailClaim, StringComparison.OrdinalIgnoreCase));
                List<Team> teams = _teamService.GetAllTeams();
                TeamList = new SelectList(teams, nameof(Team.TeamId), nameof(Team.TeamName));
                if (PictureURL != null)
                {
                    if (PictureURL.Length > 0)
                    {
                        using (var target = new MemoryStream())
                        {
                            PictureURL.CopyTo(target);
                            Campaign.PictureUrl  = target.ToArray();
                        }
                    }
                }
                Campaign.CreatedDate = DateTime.Now;
                Campaign.CreatedBy =user.Username != null ? user.Username : "Admin";
            }
            campaignService.AddCampaign(Campaign);
            return RedirectToPage("./Index");
        }
    }
}

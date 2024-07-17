using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly ICampaignService campaignService;
        private readonly ITeamService _teamService;

        public CreateModel(ICampaignService campaignSer, ITeamService teamService)
        {
            campaignService = campaignSer;
            _teamService = teamService;
        }

        public IActionResult OnGet()
        {
            var teams = _teamService.GetAllTeams();
            TeamList = new SelectList(teams, nameof(Team.TeamId), nameof(Team.TeamName));
            return Page();
        }

        [BindProperty]
        public Campaign Campaign { get; set; } = default!;
        public SelectList TeamList { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var teams = _teamService.GetAllTeams();
                TeamList = new SelectList(teams, nameof(Team.TeamId), nameof(Team.TeamName));
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }
            campaignService.AddCampaign(Campaign);
            return RedirectToPage("./Index");
        }
    }
}

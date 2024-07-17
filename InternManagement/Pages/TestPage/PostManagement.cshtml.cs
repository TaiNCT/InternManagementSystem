using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.TestPage
{
    [AllowAnonymous]
    public class PostManagementModel : PageModel
    {
        private readonly ICampaignService _campaignService;
        private readonly ITeamService _teamService;

        public PostManagementModel(ICampaignService campaignService,
                                   ITeamService teamService)
        {
            _campaignService = campaignService;
            _teamService = teamService;
        }

        public List<Campaign> Campaigns { get; set; }
        public Campaign Campaign { get; set; }

        [BindProperty]
        public Campaign SelectedCampaign { get; set; }

        public void OnGet()
        {
            Campaigns = _campaignService.GetCampaigns();
        }

        public IActionResult OnPostApply(int campaignId)
        {
            // Handle the apply action here
            // For example, you could add logic to apply the current user to the selected campaign
            return RedirectToPage();
        }
    }
}

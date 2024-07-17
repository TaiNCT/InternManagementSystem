using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages
{
    [AllowAnonymous]
    public class HomePageModel : PageModel
    {
        private readonly ICampaignService _campaignService;
        private readonly ITeamService _teamService;

        public HomePageModel(ICampaignService campaignService,
                             ITeamService teamService)
        {
            _campaignService = campaignService;
            _teamService = teamService;
        }

        public List<Campaign> Campaigns { get; set; }

        // Thêm m?t danh sách ?? l?u tên ??i cho t?ng chi?n d?ch
        public Dictionary<int, string> TeamNames { get; set; }

        public void OnGet()
        {
            Campaigns = _campaignService.GetCampaigns();

            // Kh?i t?o Dictionary ?? l?u tên ??i
            TeamNames = new Dictionary<int, string>();

            // L?p qua t?ng chi?n d?ch và l?y tên ??i t? TeamService
            foreach (var campaign in Campaigns)
            {
                var team = _teamService.GetTeamById(campaign.TeamId);
                if (team != null)
                {
                    TeamNames[campaign.TeamId] = team.TeamName;
                }
            }
        }


        public IActionResult OnPostApply(int campaignId)
        {
            // Handle the apply action here
            // For example, you could add logic to apply the current user to the selected campaign
            return RedirectToPage();
        }
    }
}

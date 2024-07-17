using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ICampaignService campaignService;
        private readonly ITeamService _teamService;


        public IndexModel(ICampaignService campaignSer, ITeamService teamService)
        {
            campaignService = campaignSer;
            _teamService = teamService;
        }

        public IList<Campaign> Campaigns { get; set; } = new List<Campaign>();

        public async Task OnGetAsync()
        {
            Campaigns = campaignService.GetCampaigns();

            foreach (var campaign in Campaigns)
            {
                campaign.Team = await _teamService.GetTeamByIdAsync(campaign.TeamId);
            }
        }
    }
}


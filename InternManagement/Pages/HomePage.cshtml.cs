using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages
{
    [AllowAnonymous]
    public class HomePageModel : PageModel
    {
        private readonly ICampaignService _campaignService;
        public List<Campaign> Campaigns { get; set; }
        public HomePageModel(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
        public void OnGet()
        {
            Campaigns = _campaignService.GetCampaigns();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IMSBussinessObjects;
using IMSServices;

namespace InternManagement.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ICampaignService campaignService;

        public IndexModel(ICampaignService campaignSer)
        {
            campaignService = campaignSer;
        }

        public IList<Campaign> Campaign { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (campaignService.GetCampaigns != null)
            {
                Campaign = campaignService.GetCampaigns();
            }
        }
    }
}

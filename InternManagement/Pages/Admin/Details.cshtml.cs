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
    public class DetailsModel : PageModel
    {
        private readonly ICampaignService campaignService;

        public DetailsModel(ICampaignService campaignSer)
        {
            campaignService = campaignSer;
        }

      public Campaign Campaign { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || campaignService.GetCampaigns() == null)
            {
                return NotFound();
            }

            var campaign = campaignService.GetCampaignById(id);
            if (campaign == null)
            {
                return NotFound();
            }
            else 
            {
                Campaign = campaign;
            }
            return Page();
        }
    }
}

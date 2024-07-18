using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;

namespace InternManagement.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
      
        private readonly ICampaignService campaignService;

        public DeleteModel(ICampaignService campaignSer)
        {
            campaignService = campaignSer;
        }

        [BindProperty]
      public Campaign Campaign { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || campaignService.GetCampaigns == null)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || campaignService.GetCampaigns == null)
            {
                return NotFound();
            }
            var campaign = campaignService.GetCampaignById(id);

            if (campaign != null)
            {
                Campaign = campaign;
               campaignService.RemoveCampaign(id);
            }

            return RedirectToPage("./Index");
        }
    }
}

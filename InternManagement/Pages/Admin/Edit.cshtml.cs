using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMSBussinessObjects;
using IMSServices;

namespace InternManagement.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly ICampaignService campaignService;

        public EditModel(ICampaignService campaignSer)
        {
            campaignService = campaignSer;
        }

        [BindProperty]
        public Campaign Campaign { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || campaignService.GetCampaigns() == null)
            {
                return NotFound();
            }

            var campaign =  campaignService.GetCampaignById(id);
            if (campaign == null)
            {
                return NotFound();
            }
            Campaign = campaign;
          // ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //campaignService.update
            return RedirectToPage("./Index");
        }

        private bool CampaignExists(int id)
        {
          if(campaignService.GetCampaignById(id) != null)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}

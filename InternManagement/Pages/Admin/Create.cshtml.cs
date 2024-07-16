using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IMSBussinessObjects;
using IMSServices;

namespace InternManagement.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly ICampaignService campaignService;

        public CreateModel(ICampaignService campaignSer)
        {
            campaignService = campaignSer;
        }

        public IActionResult OnGet()
        {
        //ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamName");
            return Page();
        }

        [BindProperty]
        public Campaign Campaign { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || campaignService.GetCampaigns == null || Campaign == null)
            {
                return Page();
            }
            campaignService.AddCampaign(Campaign);
            return RedirectToPage("./Index");
        }
    }
}

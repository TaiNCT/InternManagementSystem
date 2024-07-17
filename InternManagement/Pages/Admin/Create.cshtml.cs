using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IMSBussinessObjects;
using IMSServices;
using System.Security.Claims;

namespace InternManagement.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly ICampaignService campaignService;
        private readonly ITeamService teamService;  
        private readonly IUserService userService;

        public CreateModel(ICampaignService campaignSer, ITeamService teamSer, IUserService userSer)
        {
            campaignService = campaignSer;
            teamService = teamSer;
            userService= userSer;
        }
       // [BindProperty]
       // public int TeamId { get; set; }
        [BindProperty]
        public Campaign Campaign { get; set; } = default!;
        [BindProperty]
        public List<SelectListItem> TeamSelectListItem { get; set; }
        public async Task OnGetAsync()
        {
            TeamSelectListItem = teamService.GetAllTeams()
                .Select(t => new SelectListItem
                {
                    Value = t.TeamId.ToString(),
                    Text = t.TeamName
                })
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userEmailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
            if (!string.IsNullOrEmpty(userEmailClaim))
            {
                var user = userService.GetUsers().SingleOrDefault(x => x.Email == userEmailClaim);
                string userName = null;
                if (user.Username == null)
                {
                    userName = "Admin";
                }
                else
                {
                    userName = user.Username;
                }
                Campaign.StartDate = DateTime.Now;
                Campaign.CreatedBy = userName;

                campaignService.AddCampaign(Campaign);
               
            }
            return RedirectToPage("./Index");
        }
    }
}

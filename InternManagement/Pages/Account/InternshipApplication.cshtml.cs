using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.Account
{
    public class InternshipApplicationModel : PageModel
    {
        private readonly IInternService _internService;
        private readonly IWebHostEnvironment _environment;
        private readonly ITeamService _teamService;
        public InternshipApplicationModel(IInternService internService, ITeamService teamService, IWebHostEnvironment environment)
        {
            _internService = internService;
            _teamService = teamService;
            _environment = environment;
        }

        [BindProperty]
        public Intern Intern { get; set; }

        [BindProperty]
        public IFormFile CvFile { get; set; }

        [BindProperty]
        public IFormFile PhotoFile { get; set; }
        public SelectList Teams { get; set; }

        public void OnGet()
        {
            Teams = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (CvFile != null && PhotoFile != null)
                {
                    if (CvFile.Length > 0 && PhotoFile.Length > 0)
                    {
                        using (var target = new MemoryStream())
                        {
                            CvFile.CopyTo(target);
                            Intern.CvUrl = target.ToArray();
                            PhotoFile.CopyTo(target);
                            Intern.PhotoUrl = target.ToArray();
                        }

                    }
                }
                Intern.Status = "waiting";
                _internService.AddIntern(Intern);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                // Log the error and add a model error for the user
                ModelState.AddModelError(string.Empty, "File upload failed. Please try again.");
                Teams = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
                return Page();
            }
        }
    }
}
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
        /*private readonly ITeamService _teamService;*/

        public InternshipApplicationModel(IInternService internService, IWebHostEnvironment environment)
        {
            _internService = internService;
            _environment = environment;
        }

        /*public InternshipApplicationModel(IInternService internService, ITeamService teamService, IWebHostEnvironment environment)
        {
            _internService = internService;
            _teamService = teamService;
            _environment = environment;
        }*/

        [BindProperty]
        public Intern Intern { get; set; }

        [BindProperty]
        public IFormFile CvFile { get; set; }

        [BindProperty]
        public IFormFile PhotoFile { get; set; }
        public List<SelectListItem> TeamOptions { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadTeamOptions();
                return Page();
            }

            try
            {
                if (CvFile != null)
                {
                    var cvPath = Path.Combine(_environment.WebRootPath, "uploads", CvFile.FileName);
                    using (var stream = new FileStream(cvPath, FileMode.Create))
                    {
                        await CvFile.CopyToAsync(stream);
                    }
                    Intern.CvUrl = "/uploads/" + CvFile.FileName;
                }

                if (PhotoFile != null)
                {
                    var photoPath = Path.Combine(_environment.WebRootPath, "uploads", PhotoFile.FileName);
                    using (var stream = new FileStream(photoPath, FileMode.Create))
                    {
                        await PhotoFile.CopyToAsync(stream);
                    }
                    Intern.PhotoUrl = "/uploads/" + PhotoFile.FileName;
                }

                Intern.Status = "waiting";
                _internService.AddIntern(Intern);

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                // Log the error and add a model error for the user
                ModelState.AddModelError(string.Empty, "File upload failed. Please try again.");
                return Page();
            }
        }
        private void LoadTeamOptions()
        {
            /*var teams = _teamService.GetAllTeams();
            TeamOptions = teams.Select(t => new SelectListItem
            {
                Value = t.TeamId.ToString(),
                Text = t.TeamName
            }).ToList();*/
        }
    }
}
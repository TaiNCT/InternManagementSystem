using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Account
{
    public class InternshipApplicationModel : PageModel
    {
        private readonly IInternService _internService;

        [BindProperty]
        public Intern Intern { get; set; }

        [BindProperty]
        public IFormFile CvFile { get; set; }

        [BindProperty]
        public IFormFile PhotoFile { get; set; }

        public InternshipApplicationModel(IInternService internService)
        {
            _internService = internService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (CvFile != null)
            {
                var cvFilePath = Path.Combine("wwwroot/uploads/cvs", CvFile.FileName);
                using (var stream = new FileStream(cvFilePath, FileMode.Create))
                {
                    await CvFile.CopyToAsync(stream);
                }
                Intern.CvUrl = $"/uploads/cvs/{CvFile.FileName}";
            }

            if (PhotoFile != null)
            {
                var photoFilePath = Path.Combine("wwwroot/uploads/photos", PhotoFile.FileName);
                using (var stream = new FileStream(photoFilePath, FileMode.Create))
                {
                    await PhotoFile.CopyToAsync(stream);
                }
                Intern.PhotoUrl = $"/uploads/photos/{PhotoFile.FileName}";
            }

            Intern.Status = "waiting";
            _internService.AddIntern(Intern);

            return RedirectToPage("/Account/ApplicationSubmitted");
        }
    }
}

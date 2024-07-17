using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace InternManagement.Pages.Interns
{
    [Authorize(Roles = "Intern, Admin")]

    public class EditModel : PageModel
    {
        private readonly IInternService _internService;

        public EditModel(IInternService internService)
        {
            _internService = internService;
        }

        [BindProperty]
        public Intern Intern { get; set; }

        [BindProperty]
        [Display(Name = "New CV")]
        public IFormFile? NewCv { get; set; }

        [BindProperty]
        [Display(Name = "New Photo")]
        public IFormFile? NewPhoto { get; set; }

        public IActionResult OnGet(int id)
        {
            Intern = _internService.GetInternById(id);

            if (Intern == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {


            var existingIntern = _internService.GetInternById(Intern.InternId);

            if (existingIntern == null)
            {
                return NotFound();
            }

            // Update only allowed fields
            existingIntern.FullName = Intern.FullName;
            existingIntern.PhoneNumber = Intern.PhoneNumber;
            existingIntern.Birthday = Intern.Birthday;
            existingIntern.Uni = Intern.Uni;
            existingIntern.Major = Intern.Major;
            existingIntern.Gpa = Intern.Gpa;
            existingIntern.OverallSuccess = Intern.OverallSuccess;

            if (NewCv != null && NewCv.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    NewCv.CopyTo(memoryStream);
                    existingIntern.CvUrl = memoryStream.ToArray();
                }
            }

            if (NewPhoto != null && NewPhoto.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    NewPhoto.CopyTo(memoryStream);
                    existingIntern.PhotoUrl = memoryStream.ToArray();
                }
            }

            _internService.UpdateIntern(existingIntern.InternId, existingIntern);

            // Update status separately if it has changed
            if (existingIntern.Status != Intern.Status)
            {
                _internService.UpdateInternStatus(existingIntern.InternId, Intern.Status);
            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToPage("/Interns/ManageInterns");
            }
            else
            {
                return RedirectToPage("/Intern/InternProfile", new { id = Intern.InternId });
            }
        }
    }
}
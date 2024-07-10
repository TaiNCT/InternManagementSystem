using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Admin
{
    public class ApproveInternshipsModel : PageModel
    {
        private readonly IInternService _internService;
        private readonly IUserService _userService;

        public List<Intern> WaitingInterns { get; set; }
        public List<Intern> ArchivedInterns { get; set; }

        public ApproveInternshipsModel(IInternService internService, IUserService userService)
        {
            _internService = internService;
            _userService = userService;
        }

        public void OnGet()
        {
            var interns = _internService.GetAllIntern();
            WaitingInterns = interns.Where(i => i.Status == "waiting").ToList();
            ArchivedInterns = interns.Where(i => i.Status != "waiting").ToList();
        }

        public IActionResult OnPostApprove(int id)
        {
            var intern = _internService.GetInternById(id);
            if (intern != null)
            {
                // Create a new user for the intern
                var user = new User
                {
                    Username = intern.FullName,
                    Email = intern.Email,
                    Password = "123456", // This should be securely handled
                    Role = 3 // Intern
                };
                _userService.AddUser(user);

                // Update intern's UserId and status
                intern.UserId = user.UserId;
                intern.Status = "approved";
                _internService.UpdateIntern(intern.InternId, intern);
            }

            return RedirectToPage();
        }

        public IActionResult OnPostReject(int id)
        {
            var intern = _internService.GetInternById(id);
            if (intern != null)
            {
                intern.Status = "rejected";
                _internService.UpdateIntern(intern.InternId, intern);
            }

            return RedirectToPage();
        }

        public IActionResult OnPostRemove(int id)
        {
            _internService.RemoveIntern(id);
            return RedirectToPage();
        }
    }
}

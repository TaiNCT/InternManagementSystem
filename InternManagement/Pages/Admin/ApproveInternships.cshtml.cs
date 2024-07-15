using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Admin
{
    [Authorize]
    public class ApproveInternshipsModel : PageModel
    {
        private readonly IInternService _internService;
        private readonly IUserService _userService;
        private readonly IMailServices _mailService;

        public List<Intern> WaitingInterns { get; set; }
        public List<Intern> ArchivedInterns { get; set; }

        public ApproveInternshipsModel(IInternService internService, IUserService userService, IMailServices mailService)
        {
            _internService = internService;
            _userService = userService;
            _mailService = mailService;
        }

        public void OnGet()
        {
            var interns = _internService.GetAllIntern();
            WaitingInterns = interns.Where(i => i.Status.Equals("waiting")).ToList();
            ArchivedInterns = interns.Where(i => !i.Status.Equals("waiting")).ToList();
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
                    Role = 3, // Intern
                };
                _userService.AddUser(user);

                // sent email 
                var emailParams = new Dictionary<string, string>()
                    {
                        { "Name", $"{user.Username}" },

                    };
                List<string> toAddress = new List<string> { user.Email };
                _mailService.SendAsync(EmailType.Welcome_Email, toAddress, new List<string> { }, emailParams);

                // Update intern's UserId and status
                intern.UserId = user.UserId;
                _internService.UpdateInternStatus(id, "approved");
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
                _internService.UpdateInternStatus(id, "rejected");
                _internService.UpdateIntern(intern.InternId, intern);
            }

            return RedirectToPage();
        }

        public IActionResult OnPostRemove(int id)
        {
            _internService.RemoveIntern(id);
            return RedirectToPage();
        }

        public IActionResult OnGetInternDetails(int id)
        {
            var intern = _internService.GetInternById(id);
            if (intern == null)
            {
                return NotFound();
            }

            return Partial("_InternDetails", intern);
        }
    }
}

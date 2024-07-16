using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace InternManagement.Pages.Interns
{
    [Authorize(Roles = "Intern")]
    public class InternProfileModel : PageModel
    {
        private readonly IInternService _internService;
        private readonly IAssignmentService _assignmentService;
        private readonly IUserService _userService;

        public InternProfileModel(IInternService internServ, IAssignmentService assignmentServ, IUserService userServ)
        {
            _internService = internServ;
            _assignmentService = assignmentServ;
            _userService = userServ;
        }

        public List<Assignment> Assignments { get; set; }
        [BindProperty]
        public Intern SelectedIntern { get; set; }

        public void OnGet()
        {
            // Get the logged-in user's ID
            var userEmailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
            if (!string.IsNullOrEmpty(userEmailClaim))
            {
                // Get the user details by mail
                var user = _userService.GetUsers().SingleOrDefault(x => x.Email == userEmailClaim);
                if (user != null && user.Role == 3) // Role 3 is for Intern
                {
                    // Get the intern details associated with the user
                    SelectedIntern = _internService.GetAllIntern().SingleOrDefault(x => x.UserId == user.UserId);
                    if (SelectedIntern != null)
                    {
                        // Get assignments for the selected intern
                        Assignments = _assignmentService.GetAssignmentByInternId(SelectedIntern.InternId);
                    }
                }
            }
        }
    }
}

using IMSBussinessObjects;
using IMSRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace InternManagement.Pages.Interns
{
    [Authorize(Roles = "Intern")]
    public class InternProfileModel : PageModel
    {
        private readonly IInternRepository _internRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUserRepository _userRepository;

        public InternProfileModel(IInternRepository internRepository, IAssignmentRepository assignmentRepository, IUserRepository userRepository)
        {
            _internRepository = internRepository;
            _assignmentRepository = assignmentRepository;
            _userRepository = userRepository;
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
                var user = _userRepository.GetUsers().SingleOrDefault(x => x.Email == userEmailClaim);
                if (user != null && user.Role == 3) // Role 3 is for Intern
                {
                    // Get the intern details associated with the user
                    SelectedIntern = _internRepository.GetAllIntern().SingleOrDefault(x => x.UserId == user.UserId);
                    if (SelectedIntern != null)
                    {
                        // Get assignments for the selected intern
                        Assignments = _assignmentRepository.GetAssignmentByInternId(SelectedIntern.InternId);
                    }
                }
            }
        }
    }
}

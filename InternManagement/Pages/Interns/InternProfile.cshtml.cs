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
            var userEmailClaim = User.FindFirst(ClaimTypes.Email)?.Value;
            if (!string.IsNullOrEmpty(userEmailClaim))
            {
                // Get the user details by email
                var user = _userService.GetUsers().SingleOrDefault(x => x.Email == userEmailClaim);
                if (user != null && user.Role == 3) // Role 3 is for Intern
                {
                    SelectedIntern = _internService.GetAllIntern().SingleOrDefault(x => x.UserId == user.UserId);
                    if (SelectedIntern != null)
                    {
                        Assignments = _assignmentService.GetAssignmentByInternId(SelectedIntern.InternId);

                     //   LogAssignmentsToConsole(Assignments);
                        CalculateOverallSuccess();
                    }
                }
            }
        }


        private void CalculateOverallSuccess()
        {
            if (Assignments != null && Assignments.Any())
            {
                double totalWeightedGrade = 0;
                double totalWeight = 0;

                foreach (var assignment in Assignments)
                {
                    if (assignment.Grade.HasValue && assignment.Weight.HasValue)
                    {
                        // Tính tổng điểm có trọng số
                        totalWeightedGrade += assignment.Grade.Value * (assignment.Weight.Value / 100.0); // Chia cho 100 để tính toán theo phần trăm
                        totalWeight += assignment.Weight.Value; // Tổng trọng số, vẫn là phần trăm
                    }
                }

                if (totalWeight > 0)
                {
                    // Tính toán Overall Success dựa trên phần trăm
                    SelectedIntern.OverallSuccess = (int)(totalWeightedGrade / totalWeight * 100); // Chuyển đổi thành phần trăm
                }
                else
                {
                    SelectedIntern.OverallSuccess = 0;
                }
            }
            else
            {
                SelectedIntern.OverallSuccess = 0;
            }
        }

        private void LogAssignmentsToConsole(List<Assignment> assignments)
        {
            Console.WriteLine($"Assignments for Intern {SelectedIntern.FullName}:");
            foreach (var assignment in assignments)
            {
                Console.WriteLine($"Assignment Id: {assignment.AssignmentId}");
                Console.WriteLine($"Description: {assignment.Description}");
                Console.WriteLine($"Deadline: {assignment.Deadline}");
                Console.WriteLine($"Grade: {assignment.Grade}");
                Console.WriteLine($"Weight: {assignment.Weight}");
                Console.WriteLine($"Complete: {assignment.Complete}");
                Console.WriteLine("------------------------");
            }
        }

    }
}

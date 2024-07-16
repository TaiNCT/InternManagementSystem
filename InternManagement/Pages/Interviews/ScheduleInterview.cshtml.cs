using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Interviews
{
    [Route("/Interviews/ScheduleInterview")]
    public class ScheduleInterviewModel : PageModel
    {
        private readonly IInterviewService _interviewService;
        private readonly IInternService _internService;
        private readonly ITeamService _teamService;
        private readonly ISupervisorService _supervisorService;
        private readonly IMailServices _mailService;
        private readonly IUserService _userService;

        public ScheduleInterviewModel(
            IInterviewService interviewService,
            IInternService internService,
            ITeamService teamService,
            ISupervisorService supervisorService,
            IMailServices mailService,
            IUserService userService)
        {
            _interviewService = interviewService;
            _internService = internService;
            _teamService = teamService;
            _supervisorService = supervisorService;
            _mailService = mailService;
            _userService = userService;
        }

        [BindProperty]
        public Interview Interview { get; set; }
        public Intern Intern { get; set; }
        public Team Team { get; set; }
        public Supervisor Supervisor { get; set; }
        public string SupervisorEmail { get; set; }

        public IActionResult OnGet(int interviewId)
        {
            Interview = _interviewService.GetInterviewById(interviewId);
            if (Interview == null)
            {
                return NotFound();
            }

            Intern = _internService.GetInternById(Interview.InternId);
            if (Intern == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            Team = _teamService.GetTeamById(Interview.TeamId);
            Supervisor = _supervisorService.GetSupervisorById(Interview.SupervisorId);

            // Fetch the supervisor's email
            if (Supervisor != null && Supervisor.UserId != null)
            {
                var user = _userService.GetUserById(Supervisor.UserId);
                SupervisorEmail = user?.Email;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                    }
                }
                Intern = _internService.GetInternById(Interview.InternId);
                if (Intern == null)
                {
                    // Handle the case when the Intern is not found
                    return new StatusCodeResult(StatusCodes.Status404NotFound);
                }
                Team = _teamService.GetTeamById(Interview.TeamId);
                Supervisor = _supervisorService.GetSupervisorById(Interview.SupervisorId);
                return Page();
            }

            var existingInterview = _interviewService.GetInterviewById(Interview.InterviewId);
            if (existingInterview == null)
            {
                return NotFound();
            }

            existingInterview.InterviewDate = Interview.InterviewDate;
            existingInterview.Location = Interview.Location;
            existingInterview.RoomNumber = Interview.RoomNumber;

            _interviewService.UpdateInterview(existingInterview.InterviewId, existingInterview);

            // Fetch the Intern and Supervisor information
            Intern = _internService.GetInternById(existingInterview.InternId);
            Supervisor = _supervisorService.GetSupervisorById(existingInterview.SupervisorId);

            if (Intern != null && !string.IsNullOrWhiteSpace(Intern.Email))
            {
                // Send email to Intern
                var emailParamsIntern = new Dictionary<string, string>()
        {
            { "Name", Intern.FullName },
            { "InterviewDate", Interview.InterviewDate.ToString() },
            { "InterviewPlace", Interview.Location },
            { "Room", Interview.RoomNumber },
        };
                List<string> toAddressIntern = new List<string> { Intern.Email };
                _mailService.SendAsync(EmailType.Interview_Intern, toAddressIntern, new List<string>(), emailParamsIntern);
            }
            else
            {
                // Log error or handle the case when Intern is not found or has no email
                Console.WriteLine($"Intern with ID {existingInterview.InternId} not found or has no email.");
                // You might want to add this information to ModelState or use a different way to inform the user
                ModelState.AddModelError("", "Unable to send email to intern: intern not found or email missing.");
            }

            if (Supervisor?.User != null && !string.IsNullOrWhiteSpace(Supervisor.User.Email))
            {
                // Send mail to Supervisor
                var emailParamsSuperVisor = new Dictionary<string, string>()
        {
            { "SupervisorName", Supervisor.User.Username },
            { "InternName", Intern?.FullName ?? "N/A" },
            { "InterviewDate", Interview.InterviewDate.ToString() },
            { "InterviewPlace", Interview.Location },
            { "Room", Interview.RoomNumber },
        };
                List<string> toAddressSuperVisor = new List<string> { SupervisorEmail };
                _mailService.SendAsync(EmailType.Interview_Supervisor, toAddressSuperVisor, new List<string>(), emailParamsSuperVisor);
            }
            else
            {
                // Log error or handle the case when Supervisor or Supervisor.User is not found or has no email
                Console.WriteLine($"Supervisor with ID {existingInterview.SupervisorId} not found, has no associated User, or has no email.");
                ModelState.AddModelError("", "Unable to send email to supervisor: supervisor not found or email missing.");
            }



            return RedirectToPage("./Index");
        }
    }
}
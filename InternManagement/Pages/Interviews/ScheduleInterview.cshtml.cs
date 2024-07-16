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
        private readonly INotificationService _notificationService;
        private readonly IMailServices _mailService;

        public ScheduleInterviewModel(
            IInterviewService interviewService,
            IInternService internService,
            ITeamService teamService,
            ISupervisorService supervisorService,
            INotificationService notificationService,
            IMailServices mailService)
        {
            _interviewService = interviewService;
            _internService = internService;
            _teamService = teamService;
            _supervisorService = supervisorService;
            _notificationService = notificationService;
            _mailService = mailService;
        }

        [BindProperty]
        public Interview Interview { get; set; }
        public Intern Intern { get; set; }
        public Team Team { get; set; }
        public Supervisor Supervisor { get; set; }

        public IActionResult OnGet(int interviewId)
        {
            Interview = _interviewService.GetInterviewById(interviewId);
            if (Interview == null)
            {
                return NotFound();
            }
            Intern = _internService.GetInternById(Interview.InternId);
            Team = _teamService.GetTeamById(Interview.TeamId);
            Supervisor = _supervisorService.GetSupervisorById(Interview.SupervisorId);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Intern = _internService.GetInternById(Interview.InternId);
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

            // Send mail intern
            var emailParamsIntern = new Dictionary<string, string>()
                    {
                        { "Name", $"{Intern.FullName}" },
                        { "InterviewDate", $"{Interview.InterviewDate}" },
                        { "InterviewPlace", $"{Interview.Location}" },
                        { "Room", $"{Interview.RoomNumber}" },
                    };
            List<string> toAddressIntern = new List<string> { Intern.Email };
            _mailService.SendAsync(EmailType.Interview_Intern, toAddressIntern, new List<string> { }, emailParamsIntern);

            // Send mail Supervisor
            var emailParamsSuperVisor = new Dictionary<string, string>()
                    {
                        { "SupervisorName", $"{Supervisor.User.Username}" },
                        { "InternName", $"{Intern.FullName}" },
                        { "InterviewDate", $"{Interview.InterviewDate}" },
                        { "InterviewPlace", $"{Interview.Location}" },
                        { "Room", $"{Interview.RoomNumber}" },
                    };
            List<string> toAddressSuperVisor = new List<string> { Supervisor.User.Email };
            _mailService.SendAsync(EmailType.Interview_Intern, toAddressSuperVisor, new List<string> { }, emailParamsSuperVisor);
            SendNotification(existingInterview);

            return RedirectToPage("./Index");
        }

        private void SendNotification(Interview interview)
        {
            var notification = new Notification
            {
                UserId = Supervisor.UserId,
                InternId = Intern.InternId,
                NotificationDate = 1,
                TypeCode = 2, // Interview Scheduled
                Content = $"Interview scheduled with {Intern.FullName} on {interview.InterviewDate}",
                Timestamp = DateTime.Now,
                IsSeen = false
            };
            _notificationService.AddNotification(notification);
        }
    }
}
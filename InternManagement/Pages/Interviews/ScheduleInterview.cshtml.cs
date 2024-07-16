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

        public ScheduleInterviewModel(
            IInterviewService interviewService,
            IInternService internService,
            ITeamService teamService,
            ISupervisorService supervisorService,
            INotificationService notificationService)
        {
            _interviewService = interviewService;
            _internService = internService;
            _teamService = teamService;
            _supervisorService = supervisorService;
            _notificationService = notificationService;
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
using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.Interviews
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IInterviewService _interviewService;
        private readonly IInternService _internService;
        private readonly ITeamService _teamService;
        private readonly ISupervisorService _supervisorService;

        public IndexModel(
            IInterviewService interviewService,
            IInternService internService,
            ITeamService teamService,
            ISupervisorService supervisorService)
        {
            _interviewService = interviewService;
            _internService = internService;
            _teamService = teamService;
            _supervisorService = supervisorService;
        }

        public IList<Interview> Interviews { get; set; }

        public void OnGet()
        {
            // Get all interviews
            Interviews = _interviewService.GetAllInterview();

            // Filter out expired interviews
            Interviews = Interviews.Where(i => i.InterviewDate == null || i.InterviewDate >= DateTime.Now).ToList();

            // Populate related properties
            foreach (var interview in Interviews)
            {
                interview.Intern = _internService.GetInternById(interview.InternId);
                interview.Team = _teamService.GetTeamById(interview.TeamId);
                interview.Supervisor = _supervisorService.GetSupervisorById(interview.SupervisorId);
            }

            // Remove expired interviews from the database
            var expiredInterviews = Interviews.Where(i => i.InterviewDate != null && i.InterviewDate < DateTime.Now).ToList();
            _interviewService.RemoveExpiredInterviews(expiredInterviews);
        }
    }
}
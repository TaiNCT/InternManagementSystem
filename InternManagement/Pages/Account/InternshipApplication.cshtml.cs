using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternManagement.Pages.Account
{
    public class InternshipApplicationModel : PageModel
    {
        private readonly IInternService _internService;
        private readonly IWebHostEnvironment _environment;
        private readonly ITeamService _teamService;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        private readonly IInterviewService _interviewService;
        private readonly ISupervisorService _supervisorService;
        private readonly ICampaignService _campaignService;

        public InternshipApplicationModel(IInternService internService, ITeamService teamService,
            IWebHostEnvironment environment, INotificationService notificationService,
            IUserService userService, IInterviewService interviewServ,
            ISupervisorService supervisorService, ICampaignService campaignService)
        {
            _internService = internService;
            _teamService = teamService;
            _environment = environment;
            _notificationService = notificationService;
            _userService = userService;
            _interviewService = interviewServ;
            _supervisorService = supervisorService;
            _campaignService = campaignService;

            Intern = new Intern(); // Initialize Intern
            Supervisors = new List<Supervisor>();
        }

        [BindProperty]
        public Intern Intern { get; set; }

        [BindProperty]
        public IFormFile CvFile { get; set; }

        [BindProperty]
        public IFormFile PhotoFile { get; set; }

        [BindProperty]
        public int SelectedTeamId { get; set; }
        public SelectList Teams { get; set; }
        public List<User> Users { get; set; }
        public List<Supervisor> Supervisors { get; set; }
        public List<Campaign> Campaigns { get; set; }

        public void OnGet(int? teamId, DateTime? startDate, DateTime? endDate)
        {
            Teams = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");

            if (Intern == null)
            {
                Intern = new Intern(); // Ensure Intern is not null
            }

            if (teamId.HasValue)
            {
                SelectedTeamId = teamId.Value;
            }

            if (startDate.HasValue)
            {
                Intern.InternshipStartingDate = startDate.Value;
            }

            if (endDate.HasValue)
            {
                Intern.InternshipEndingDate = endDate.Value;
            }
        }

        public async Task<IActionResult> OnPostAsync(int? teamId)
        {
            try
            {
                if (CvFile != null && PhotoFile != null)
                {
                    if (PhotoFile.Length > 0)
                    {
                        using (var target = new MemoryStream())
                        {
                            PhotoFile.CopyTo(target);
                            Intern.PhotoUrl = target.ToArray();
                        }
                    }
                    if (CvFile.Length > 0)
                    {
                        using (var target = new MemoryStream())
                        {
                            CvFile.CopyTo(target);
                            Intern.CvUrl = target.ToArray();
                        }
                    }
                }

                Intern.Status = "waiting";
                Intern.TeamId = teamId.Value;
                _internService.AddIntern(Intern);

                // Get the supervisor for the selected team
                Supervisors = _supervisorService.GetAllSupervisors();
                var supervisor = Supervisors.FirstOrDefault(s => s.TeamId == teamId.Value);

                if (supervisor == null)
                {
                    ModelState.AddModelError(string.Empty, "No supervisor found for the selected team. Please try again or contact the administrator.");
                    Teams = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
                    return Page();
                }

                var interview = new Interview
                {
                    TeamId = teamId.Value,
                    InternId = Intern.InternId,
                    SupervisorId = supervisor.SupervisorId
                    // Other fields are not set, they will remain null
                };
                _interviewService.AddInterview(interview);

                Users = _userService.GetUsers().Where(x => x.Role == 1).ToList();

                foreach (User user in Users)
                {
                    Notification notification = new Notification()
                    {
                        UserId = user.UserId,
                        InternId = Intern.InternId,
                        NotificationDate = 3,
                        TypeCode = 1, //Approve Internship
                        Content = $"{_internService.GetInternsByStatus("waiting").Count} application is waiting",
                        Timestamp = DateTime.Now,
                        IsSeen = false,
                    };
                    if (_notificationService.GetNotificationById(notification.NotificationId) == null)
                    {
                        _notificationService.AddNotification(notification);
                    }
                    else
                    {
                        Notification newNotification = _notificationService.GetNotificationById(notification.NotificationId);
                        if (newNotification != null)
                        {
                            newNotification.Content = $"{_internService.GetInternsByStatus("waiting").Count} application is waiting";
                        }
                        _notificationService.UpdateNotification(notification.NotificationId, newNotification, false);
                    }
                }

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                // Log the error and add a model error for the user
                ModelState.AddModelError(string.Empty, "Application submission failed. Please try again.");
                Teams = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
                return Page();
            }
        }
    }
}
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
        public InternshipApplicationModel(IInternService internService, ITeamService teamService, IWebHostEnvironment environment, INotificationService notificationService, IUserService userService)
        {
            _internService = internService;
            _teamService = teamService;
            _environment = environment;
            _notificationService=notificationService;
            _userService=userService;
        }

        [BindProperty]
        public Intern Intern { get; set; }

        [BindProperty]
        public IFormFile CvFile { get; set; }

        [BindProperty]
        public IFormFile PhotoFile { get; set; }
        public SelectList Teams { get; set; }

        public List<User> Users { get; set; }
        public void OnGet()
        {
            Teams = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //ModelState alway invalid
           /* if (!ModelState.IsValid)
            {
                return Page();
            }*/

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
                            target.Dispose();
                        }
                    }
                    if(CvFile.Length > 0)
                    {
                        using (var target = new MemoryStream())
                        {
                            CvFile.CopyTo(target);
                            Intern.CvUrl = target.ToArray();
                            target.Dispose();
                        }

                    }
                }
                //Some one delete this
                Intern.Status = "waiting";
                _internService.AddIntern(Intern);
                Users = _userService.GetUsers().Where(x => x.Role == 1).ToList();

                foreach (User user in Users)
                {
                    Notification notification = new Notification()
                    {
                        UserId = user.UserId,
                        InternId = Intern.InternId,
                        NotificationDate =  3,
                        TypeCode = 1, //Approve Internship
                        Content = $"{_internService.GetInternsByStatus("waiting").Count} application is waiting",
                        Timestamp = DateTime.Now,
                        IsSeen = false,

                    };
                    if (_notificationService.GetNotificationById(notification.NotificationId) == null)
                    {
                        _notificationService.AddNotification(notification);
                    }else
                    {
                        Notification newNotification = _notificationService.GetNotificationById(notification.NotificationId);
                        if (newNotification != null)
                        {
                            newNotification.Content = $"{_internService.GetInternsByStatus("waiting").Count} application is waiting";
                        }
                        _notificationService.UpdateNotification(notification.NotificationId,newNotification, false);
                    }
                }
              
            return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                // Log the error and add a model error for the user
                ModelState.AddModelError(string.Empty, "File upload failed. Please try again.");
                Teams = new SelectList(_teamService.GetAllTeams(), "TeamId", "TeamName");
                return Page();
            }
        }
    }
}
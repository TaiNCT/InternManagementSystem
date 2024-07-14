using AspNetCoreHero.ToastNotification.Helpers;
using IMSBussinessObjects;
using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;

namespace InternManagement.Pages.TestPage
{
    public class NotificationsTestModel : PageModel
    {
        private readonly INotificationService notificationService;
        private readonly IInternService userService;

        public NotificationsTestModel(INotificationService context, IInternService userService)
        {
            notificationService = context;
            this.userService=userService;   
        }
        public byte[] ImageData { get; set; }
        public string ImageSrc { get; set; }
        public IList<Notification> Notifications { get; set; }
        public IList<Intern> Users { get; set; }
        public byte[] GetImage(string url)
        {
            byte[] bytes = null;
            if(!string.IsNullOrEmpty(url))
            {
                bytes =Convert.FromBase64String(url);
            }
            return bytes;
        }
        public async Task OnGetAsync()
        {
            // Fetch notifications from the database
            // You'll need to replace this with actual logic to fetch notifications based on user role and other criteria

            Notifications = notificationService.GetNotifications();
            Users = userService.GetAllIntern();
            Intern intern = userService.GetInternById(6);
            intern.PhotoUrl = this.GetImage(Convert.ToBase64String(intern.PhotoUrl));
            ImageData = intern.PhotoUrl;
            ImageSrc = string.Format("data:image/jpg;base64,"+ Convert.ToBase64String(ImageData));
        }
    }
}

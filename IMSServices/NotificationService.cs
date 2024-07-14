using IMSBussinessObjects;
using IMSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notificationRepository;
        public NotificationService(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }
        public void AddNotification(Notification notification)
        {
            notificationRepository.AddNotification(notification);
        }

        public void DeleteNotification(int notiId)
        {
            notificationRepository.DeleteNotification(notiId);
        }

        public Notification GetNotificationById(int notiId)
        {
            return notificationRepository.GetNotificationById(notiId);
        }

        public List<Notification> GetNotifications()
        {
            return notificationRepository.GetNotifications();
        }

        public void UpdateNotification(int notiId, Notification newNotification, bool isSeen)
        {
            notificationRepository.UpdateNotification(notiId, newNotification, isSeen);
        }
    }
}

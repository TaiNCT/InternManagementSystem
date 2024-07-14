using IMSBussinessObjects;
using IMSDaos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public class NotificationRepository : INotificationRepository
    {
        public void AddNotification(Notification notification) => NotificationDAO.Instance.AddNotification(notification);
        public void DeleteNotification(int notiId) => NotificationDAO.Instance.DeleteNotification(notiId);

        public Notification GetNotificationById(int notiId) => NotificationDAO.Instance.GetNotificationById(notiId);

        public List<Notification> GetNotifications() => NotificationDAO.Instance.GetNotifications();
        public void UpdateNotification(int notiId, Notification newNotification, bool isSeen) => NotificationDAO.Instance.UpdateNotification(notiId, newNotification, isSeen);
    }
}

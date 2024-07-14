using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public interface INotificationService
    {
        public Notification GetNotificationById(int notiId);
        public List<Notification> GetNotifications();
        public void AddNotification(Notification notification);

        public void DeleteNotification(int notiId);
        public void UpdateNotification(int notiId, Notification newNotification, bool isSeen);
    }
}

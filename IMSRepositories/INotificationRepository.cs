using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public interface INotificationRepository
    {
        public Notification GetNotificationById(int notiId);
        public List<Notification> GetNotifications();
        public void AddNotification(Notification notification);

        public void DeleteNotification(int notiId);
        public void UpdateNotification(int notiId, Notification newNotification, bool isSeen);
    }
}

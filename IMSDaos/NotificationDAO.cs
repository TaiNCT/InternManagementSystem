using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDaos
{
    public class NotificationDAO
    {
        private readonly AppDbContext db = null;
        private static NotificationDAO instance = null;
        public NotificationDAO() 
        {
            db  = new AppDbContext();
        }
        public static NotificationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NotificationDAO();
                }
                return instance;
            }
        }
        public Notification GetNotificationById(int notiId)
        {
            return db.Notifications.FirstOrDefault(x => x.NotificationId == notiId);
        }
        public List<Notification> GetNotifications()
        {
            return db.Notifications.ToList();
        }

        public void AddNotification(Notification notification)
        {
            Notification newNotification = GetNotificationById(notification.NotificationId);
            if (newNotification == null)
            {
                db.Notifications.Add(notification);
                db.SaveChanges();
            }
        }

        public void DeleteNotification(int notiId)
        {
            Notification notification = GetNotificationById(notiId);
            if (notification != null)
            {
                db.Notifications.Remove(notification);
                db.SaveChanges();
            }
        }
        public void UpdateNotification(int notiId, Notification newNotification, bool isSeen)
        {
            var existingNotification = GetNotificationById(notiId);
            if (existingNotification != null)
            {
                existingNotification.IsSeen = isSeen;

                db.Notifications.Attach(existingNotification);
                db.Entry(existingNotification).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}

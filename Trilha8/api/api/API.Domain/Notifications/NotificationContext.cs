using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace API.Domain.Notification
{
    public class NotificationContext
    {
        public readonly IList<Notification> notifications;
        public bool HasNotifications => notifications.Any();

        public NotificationContext()
        {
            this.notifications = new List<Notification>();
        }

        public void Add(HttpStatusCode code, string message)
        {
            this.notifications.Add(new Notification(code, message));
        }

        public void Add(Notification notification)
        {
            this.notifications.Add(notification);
        }

        public void Add(IList<Notification> notifications)
        {
            this.notifications.Concat(notifications);
        }

        public void AddNotFoundNotification(string message)
        {
            this.notifications.Add(new Notification().InexistentId<Notification>(message));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Notification
{
    interface INotificationProvider
    {
        string Name { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        INotificationResult Notify(INotification notification);
    }
}

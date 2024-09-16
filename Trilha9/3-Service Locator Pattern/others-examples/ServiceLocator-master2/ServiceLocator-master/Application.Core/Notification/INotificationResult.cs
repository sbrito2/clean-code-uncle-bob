using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Notification
{
    public interface INotificationResult
    {
        bool IsSuccesfull { get; set; }
        string Message { get; set; }
    }
}

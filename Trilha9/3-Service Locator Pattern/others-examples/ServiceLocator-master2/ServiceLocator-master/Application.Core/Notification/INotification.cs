using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Notification
{
    interface INotification
    {
        string Sender { get; set; }
        string[] Receivers { get; set; }
        string Description { get; set; }
    }
}

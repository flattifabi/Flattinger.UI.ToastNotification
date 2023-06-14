using Flattinger.Core.Enums;
using Flattinger.Core.Interface.ToastMessage;
using Flattinger.Core.Interface.ToastMessage.Base;
using Flattinger.UI.ToastMessage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattinger.UI.ToastMessage.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationContainer notificationContainer;
        public NotificationService(NotificationContainer container) 
        {
            notificationContainer = container;
        }
        public void AddNotification(ToastType type, string title, string message, int delay)
        {
            notificationContainer.AddNotification(type, message, title, delay);
        }
        public void AddNotification(ToastType type, string title, string message, int delay, List<IToastButton> buttons)
        {
            notificationContainer.AddNotification(type, message, title, delay, buttons);
        }
    }
}

using Flattinger.Core.Interface.ToastMessage;
using Flattinger.UI.ToastMessage.Controls;
using Flattinger.UI.ToastMessage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattinger.UI.ToastMessage
{
    public class ToastProvider
    {
        public IMessageService MessageService { get; set; }
        public INotificationService NotificationService { get; set; }

        public ToastProvider(NotificationContainer notificationContainer)
        {
            MessageService = new MessageService();
            NotificationService = new NotificationService(notificationContainer);
        }
    }
}

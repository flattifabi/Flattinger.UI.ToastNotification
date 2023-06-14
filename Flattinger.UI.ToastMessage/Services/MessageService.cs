using Flattinger.Core.Enums;
using Flattinger.Core.Event;
using Flattinger.Core.Interface.ToastMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattinger.UI.ToastMessage.Services
{
    public class MessageService : IMessageService
    {
        public event EventHandler<NotificationEventArgs> MessageReceived;

        protected virtual void OnMessageReceived(NotificationEventArgs e)
        {
            MessageReceived?.Invoke(this, e);
        }
        public void SendMessage(ToastType toastType, string message, int delay = 5)
        {
            MessageReceived?.Invoke(this, new NotificationEventArgs { Delay=delay, Message=message, Type=toastType});
        }
    }
}

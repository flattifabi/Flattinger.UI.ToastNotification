using Flattinger.Core.Enums;
using Flattinger.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattinger.Core.Interface.ToastMessage
{
    public interface IMessageService
    {
        event EventHandler<NotificationEventArgs> MessageReceived;
        void SendMessage(ToastType toastType, string message, int delay = 5);
    }
}

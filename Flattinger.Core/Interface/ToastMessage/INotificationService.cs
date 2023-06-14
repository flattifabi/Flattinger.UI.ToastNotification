using Flattinger.Core.Enums;
using Flattinger.Core.Interface.ToastMessage.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattinger.Core.Interface.ToastMessage
{
    public interface INotificationService
    {
        void AddNotification(ToastType type, string title, string message, int delay);
        void AddNotification(ToastType type, string title, string message, int delay, List<IToastButton> buttons);
    }
}

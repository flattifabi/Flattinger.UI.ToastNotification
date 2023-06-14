using Flattinger.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattinger.Core.Event
{
    public class NotificationEventArgs : EventArgs
    {
        public ToastType Type { get; set; }
        public string Message { get; set; }
        public int Delay { get; set; }
    }
}

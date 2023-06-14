using Flattinger.Core.Enums;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Flattinger.Core.Interface.ToastMessage.Base
{
    public interface IToastButton
    {
        string Content { get; set; }
        bool HasBackground { get; set; }
        Brush Background { get; set; }
        Brush Foreground { get; set; }
        Action OnButtonClick { get; set; }
        object NotificationControl { get; set; }
        Action CloseCurrentNotification { get; set; }
    }
    public class ToastButton : IToastButton
    {
        public string Content { get; set; }
        public bool HasBackground { get; set; }
        public Brush Background { get; set; }
        public Brush Foreground { get; set; }
        public Action OnButtonClick { get; set; }
        public object NotificationControl { get; set; }
        public Action CloseCurrentNotification { get; set; }
    }
}

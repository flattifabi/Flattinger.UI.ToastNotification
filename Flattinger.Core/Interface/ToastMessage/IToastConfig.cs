using Flattinger.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Flattinger.Core.Interface.ToastMessage
{
    public interface IToastConfig : IToastAnimationConfig
    {

    }
    public interface IToastAnimationConfig
    {
        ToastAnimation Animation { get; set; }
    }
    public interface IDelayConfiguration
    {
        ToastDelayOption DelayOption { get; set; }
    }
    public class ToastConfig : IToastConfig
    {
        public ToastAnimation Animation { get; set; } = ToastAnimation.SLIDEDOWN;
    }
}

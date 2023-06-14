using Flattinger.Core.Enums;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Flattinger.Core.Converter
{
    public class ToastTypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ToastType type = (ToastType)value;
            switch(type)
            {
                case ToastType.INFO:
                    return "/Flattinger.UI.ToastMessage;component/Resources/info.png";
                case ToastType.ERROR:
                    return "/Flattinger.UI.ToastMessage;component/Resources/error.png";
                case ToastType.WARNING:
                    return "/Flattinger.UI.ToastMessage;component/Resources/warn.png";
                case ToastType.FATAL:
                    return "/Flattinger.UI.ToastMessage;component/Resources/fatal.png";
                default:
                    return PackIconOcticonsKind.Info;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

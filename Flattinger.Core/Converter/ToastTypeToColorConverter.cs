using Flattinger.Core.Enums;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Flattinger.Core.Converter
{
    public class ToastTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ToastType type = (ToastType)value;
            switch (type)
            {
                case ToastType.INFO:
                    return Brushes.LightBlue;
                case ToastType.WARNING:
                    return Brushes.OrangeRed;
                case ToastType.ERROR:
                    return Brushes.DarkRed;
                case ToastType.FATAL:
                    return Brushes.IndianRed;
                default:
                    return Brushes.Blue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Lsj.Util.WPF.Converters
{
    [ValueConversion(typeof(IntPtr), typeof(string), ParameterType = typeof(string))]
    public class IntPtrToHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is IntPtr ptr ? ptr.ToString(parameter as string ?? "X8") : DependencyProperty.UnsetValue;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return IntPtr.Size == 4 ? (IntPtr)int.Parse(str, NumberStyles.HexNumber, culture) : (IntPtr)long.Parse(str, NumberStyles.HexNumber, culture);
            }
            return DependencyProperty.UnsetValue;
        }
    }
}

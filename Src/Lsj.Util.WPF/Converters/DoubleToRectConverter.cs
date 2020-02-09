using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Lsj.Util.WPF.Converters
{
    /// <summary>
    /// <see cref="T:double[]"/> To <see cref="Rect"/> Converter
    /// </summary>
    [ValueConversion(typeof(double[]), typeof(Rect))]
    public class DoubleToRectConverter : IMultiValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values?.Length == 2 && targetType == typeof(Rect))
            {
                double width = (double)values[0];
                double height = (double)values[1];
                return new Rect(0, 0, width, height);
            }
            return DependencyProperty.UnsetValue;
        }

        /// <inheritdoc/>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) =>
            new[] { DependencyProperty.UnsetValue };
    }
}

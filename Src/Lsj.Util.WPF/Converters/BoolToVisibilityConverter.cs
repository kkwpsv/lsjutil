using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Lsj.Util.WPF.Converters
{
    /// <summary>
    /// <see cref="bool"/> To <see cref="Visibility"/> Converter
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Value for <see langword="true"/>
        /// </summary>
        public Visibility TrueValue { get; set; } = Visibility.Visible;

        /// <summary>
        /// Value for <see langword="false"/>
        /// </summary>
        public Visibility FalseValue { get; set; } = Visibility.Collapsed;

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is bool b && targetType == typeof(Visibility) ? b ? TrueValue : FalseValue : DependencyProperty.UnsetValue;

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

}

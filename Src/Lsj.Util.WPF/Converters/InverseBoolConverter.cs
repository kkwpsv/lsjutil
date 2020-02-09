using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Lsj.Util.WPF.Converters
{
    /// <summary>
    /// Inverse <see cref="bool"/> Converter
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBoolConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
    }
}

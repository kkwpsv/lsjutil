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
    /// Inverse <see cref="Visibility"/> Converter
    /// </summary>
    [ValueConversion(typeof(Visibility), typeof(Visibility))]
    public class InverseVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Value for <see langword="true"/>
        /// </summary>
        public Visibility InverseVisibleValue { get; set; } = Visibility.Collapsed;

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (Visibility)value is Visibility.Visible ? InverseVisibleValue : Visibility.Visible;

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (Visibility)value is Visibility.Visible ? InverseVisibleValue : Visibility.Visible;
    }
}

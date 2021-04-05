using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Lsj.Util.WPF.Converters
{
    /// <summary>
    /// <see cref="Enum"/> To <see cref="string"/> Converter
    /// </summary>
    [ValueConversion(typeof(Enum), typeof(string))]
    public class EnumToStringConverter : IValueConverter
    {
        /// <summary>
        /// Enum Type
        /// </summary>
        public Type EnumType { get; set; }

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is Enum ? value.ToString() : DependencyProperty.UnsetValue;

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var target = EnumType ?? targetType;
            return target != null && target.IsEnum && value is string str ? Enum.Parse(target, str) : throw new InvalidOperationException();
        }
    }
}

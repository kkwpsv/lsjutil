using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Lsj.Util.WPF.Converters
{
    /// <summary>
    /// If <see cref="ICollection.Count"/> is 0 To <see cref="Visibility"/> Converter
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class CollectionEmptyToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Value for <see langword="true"/>
        /// </summary>
        public Visibility NullValue { get; set; } = Visibility.Visible;

        /// <summary>
        /// Value for <see langword="true"/>
        /// </summary>
        public Visibility TrueValue { get; set; } = Visibility.Visible;

        /// <summary>
        /// Value for <see langword="false"/>
        /// </summary>
        public Visibility FalseValue { get; set; } = Visibility.Collapsed;

        ///<inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is ICollection collection && collection != null ? collection.Count == 0 ? TrueValue : FalseValue : NullValue;

        ///<inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

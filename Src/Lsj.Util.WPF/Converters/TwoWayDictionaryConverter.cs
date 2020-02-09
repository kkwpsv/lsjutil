using Lsj.Util.Collections;
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
    /// TwoWayDictionaryConverter
    /// </summary>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    public class TwoWayDictionaryConverter<TFrom, TTo> : IValueConverter
    {
        /// <summary>
        /// ConvertDictionary
        /// </summary>
        public TwoWayDictionary<TFrom, TTo> ConvertDictionary { get; set; } = new TwoWayDictionary<TFrom, TTo>();

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is TFrom val && targetType.IsAssignableFrom(typeof(TTo)) && ConvertDictionary.ContainsKey(val) ? ConvertDictionary.GetValueByKey(val) : DependencyProperty.UnsetValue;

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is TTo val && targetType.IsAssignableFrom(typeof(TFrom)) && ConvertDictionary.ContainsValue(val) ? ConvertDictionary.GetKeyByValue(val) : DependencyProperty.UnsetValue;
    }
}

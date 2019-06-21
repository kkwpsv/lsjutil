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
    public class BaseDictionaryConverter<TFrom, TTo> : IValueConverter
    {
        public Dictionary<TFrom, TTo> ConvertDictionary { get; set; } = new Dictionary<TFrom, TTo>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is TFrom val && targetType.IsAssignableFrom(typeof(TTo)) && ConvertDictionary.ContainsKey(val) ? ConvertDictionary[val] : DependencyProperty.UnsetValue;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
    }
}

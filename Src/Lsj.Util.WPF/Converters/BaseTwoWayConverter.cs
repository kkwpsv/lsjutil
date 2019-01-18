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
    /// Base Two Way Converter
    /// </summary>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTO"></typeparam>
    public abstract class BaseTwoWayConverter<TFrom, TTO> : IValueConverter
    {
        /// <summary>
        /// ConvertDictionary
        /// </summary>
        protected TwoWayDictionary<TFrom, TTO> ConvertDictionary = new TwoWayDictionary<TFrom, TTO>();

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is TFrom val && ConvertDictionary.ContainsKey(val) ? ConvertDictionary.GetValueByKey(val) : DependencyProperty.UnsetValue;


        /// <summary>
        /// ConvertBack
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value is TTO val && ConvertDictionary.ContainsValue(val) ? ConvertDictionary.GetKeyByValue(val) : DependencyProperty.UnsetValue;
    }
}

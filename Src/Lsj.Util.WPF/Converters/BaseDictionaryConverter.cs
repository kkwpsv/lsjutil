﻿using System;
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
    /// Base Dictionary Converter
    /// </summary>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    public class BaseDictionaryConverter<TFrom, TTo> : IValueConverter
    {
        /// <summary>
        /// Convert Dictionary
        /// </summary>
        public Dictionary<TFrom, TTo> ConvertDictionary { get; set; } = new Dictionary<TFrom, TTo>();

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is TFrom val && targetType.IsAssignableFrom(typeof(TTo)) && ConvertDictionary.ContainsKey(val) ? ConvertDictionary[val] : DependencyProperty.UnsetValue;

        /// <summary>
        /// ConvertBack
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
    }
}

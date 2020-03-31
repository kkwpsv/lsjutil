using Lsj.Util.Reflection;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;

namespace Lsj.Util.WPF.MarkupExtensions
{
    /// <summary>
    /// EnumToItemSourceExtension
    /// </summary>
    public class EnumToItemSourceExtension : MarkupExtension
    {
        private readonly Type _type;

        /// <summary>
        /// EnumToItemSourceExtension
        /// </summary>
        /// <param name="type">Enum Type</param>
        public EnumToItemSourceExtension(Type type)
        {
            if (type.IsEnum)
            {
                _type = type;
            }
            else
            {
                throw new ArgumentException(nameof(type));
            }
        }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _type.GetFields(BindingFlags.Static | BindingFlags.Public).Select(x => new EnumItem
            {
                Value = x.GetValue(null),
                DisplayName = x.GetAttribute<DisplayNameAttribute>()?.DisplayName ?? x.Name,
            });
        }

        /// <summary>
        /// EnumItem
        /// </summary>
        public class EnumItem
        {
            /// <summary>
            /// Enum Value
            /// </summary>
            public object Value { get; set; }

            /// <summary>
            /// Enum DisplayName
            /// </summary>
            public string DisplayName { get; set; }
        }
    }
}

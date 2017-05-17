using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


#if NETCOREAPP1_1
using Lsj.Util.Core.Text;
#else
using Lsj.Util.Text;
#endif

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Config
#else
namespace Lsj.Util.Config
#endif
{
    /// <summary>
    /// Config element.
    /// </summary>
    public class ConfigElement
    {
        string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Config.ConfigElement"/> class.
        /// </summary>
        public ConfigElement()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Config.ConfigElement"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public ConfigElement(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value => value.ToSafeString();
        /// <summary>
        /// Gets the string array value.
        /// </summary>
        /// <value>The string array value.</value>
        public string[] StringArrayValue => Value.Split(',');
        /// <summary>
        /// Gets the bool value.
        /// </summary>
        /// <value><c>true</c> if bool value; otherwise, <c>false</c>.</value>
        public bool BoolValue => Value == "True";
        /// <summary>
        /// Gets the int value.
        /// </summary>
        /// <value>The int value.</value>
        public int IntValue => Value.ConvertToInt(0);



        /// <summary>
        /// NullConfigElemnet
        /// </summary>
        public static ConfigElement Null = new ConfigElement("");
    }
}

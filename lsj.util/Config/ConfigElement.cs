using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Config
{
    /// <summary>
    /// ConfigElement
    /// </summary>
    public class ConfigElement
    {
        string value;

        /// <summary>
        /// Initial a new ConfigElemnt
        /// </summary>
        public ConfigElement()
        {
        }
        /// <summary>
        /// Initial a new ConfigElemnt with value
        /// </summary>
        /// <param name="value"></param>
        public ConfigElement(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value => value.ToSafeString();
        /// <summary>
        /// StringArrayValue
        /// </summary>
        public string[] StringArrayValue => Value.Split(',');
        /// <summary>
        /// BoolValue
        /// </summary>
        public bool BoolValue => Value == "True";
        /// <summary>
        /// IntValue
        /// </summary>
        public int IntValue => Value.ConvertToInt(0);



        /// <summary>
        /// NullConfigElemnet
        /// </summary>
        public static ConfigElement Null = new ConfigElement("");
    }
}

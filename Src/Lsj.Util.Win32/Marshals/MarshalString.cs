using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// MarshalString
    /// </summary>
    public class MarshalString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public MarshalString(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; }

        /// <inheritdoc/>
        public override string ToString() => Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public static explicit operator string(MarshalString str) => str.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public static explicit operator MarshalString(string str) => new MarshalString(str);
    }
}

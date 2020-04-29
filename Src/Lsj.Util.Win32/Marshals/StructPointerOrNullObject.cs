using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// StructPointerOrNullObject
    /// </summary>
    /// <typeparam name="T">struct type</typeparam>
    [Obsolete]
    public class StructPointerOrNullObject<T> where T : struct
    {
        /// <summary>
        /// Struct Value
        /// </summary>
        public T? Value { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public StructPointerOrNullObject(T val)
        {
            Value = val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator StructPointerOrNullObject<T>(T val) => new StructPointerOrNullObject<T>(val);
    }
}

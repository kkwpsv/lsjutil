using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// <see cref="string"/> Or <see cref="IntPtr"/> Object For P/Invoke
    /// </summary>
    public class StringOrIntPtrObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public StringOrIntPtrObject(string val)
        {
            IsString = true;
            StringVal = val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public StringOrIntPtrObject(IntPtr val)
        {
            IsString = false;
            IntPtrVal = val;
        }

        /// <summary>
        /// Is String
        /// </summary>
        public bool IsString { get; private set; }

        /// <summary>
        /// The Value of <see cref="string"/>
        /// </summary>
        public string StringVal { get; private set; }

        /// <summary>
        /// The Value of <see cref="IntPtr"/>
        /// </summary>
        public IntPtr IntPtrVal { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator StringOrIntPtrObject(string val) => new StringOrIntPtrObject(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator StringOrIntPtrObject(IntPtr val) => new StringOrIntPtrObject(val);
    }
}

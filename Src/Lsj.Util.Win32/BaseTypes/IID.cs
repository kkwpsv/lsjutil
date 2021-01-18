using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// IID
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct IID
    {
        /// <summary>
        /// IID_NULL
        /// </summary>
        public static readonly IID IID_NULL = new IID();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public IID(string value)
        {
            _value = new Guid(value);
        }

        [FieldOffset(0)]
        private Guid _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Guid(IID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IID(Guid val) => new IID { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IID(string val) => new IID { _value = new Guid(val) };
    }
}

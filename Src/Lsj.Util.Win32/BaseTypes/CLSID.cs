using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// CLSID
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct CLSID
    {
        /// <summary>
        /// CLSID_NULL
        /// </summary>
        public static readonly CLSID CLSID_NULL = new CLSID();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public CLSID(string value)
        {
            _value = new Guid(value);
        }

        [FieldOffset(0)]
        private Guid _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Guid(CLSID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CLSID(Guid val) => new CLSID { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CLSID(string val) => new CLSID { _value = new Guid(val) };
    }
}

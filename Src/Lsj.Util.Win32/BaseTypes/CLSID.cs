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
    }
}

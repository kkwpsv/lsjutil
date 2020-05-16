using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// GUID
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct GUID
    {
        [FieldOffset(0)]
        private Guid _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Guid(GUID val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator GUID(Guid val) => new GUID { _value = val };
    }
}

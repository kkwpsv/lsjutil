using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HTOUCHINPUT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTOUCHINPUT : IPointer
    {
        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HTOUCHINPUT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HTOUCHINPUT(IntPtr val) => new HTOUCHINPUT { _value = val };
    }
}

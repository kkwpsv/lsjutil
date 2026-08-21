using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// SOCKET
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct SOCKET
    {
        [FieldOffset(0)]
        private nuint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}

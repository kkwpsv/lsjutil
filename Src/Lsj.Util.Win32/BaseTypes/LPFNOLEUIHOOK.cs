using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LPFNOLEUIHOOK
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPFNOLEUIHOOK
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}

using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// <see cref="DISPID"/> is used by <see cref="IDispatch.Invoke"/> to identify methods, properties, and named arguments.
    /// </para>
    /// <para>
    /// From: https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-oaut/b0b43e39-b080-4edd-a26d-7134075c75cd
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct DISPID
    {
        /// <summary>
        /// DISPID_UNKNOWN
        /// </summary>
        public static readonly DISPID DISPID_UNKNOWN = new DISPID { _value = -1 };

        [FieldOffset(0)]
        private int _value;
    }
}

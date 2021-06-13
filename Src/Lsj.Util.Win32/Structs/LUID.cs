using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The LUID structure is 64-bit value guaranteed to be unique only on the system on which it was generated.
    /// The uniqueness of a locally unique identifier (LUID) is guaranteed only until the system is restarted.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/48cbee2a-0790-45f2-8269-931d7083b2c3"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LUID
    {
        /// <summary>
        /// The low-order bits of the structure.
        /// </summary>
        public DWORD LowPart;

        /// <summary>
        /// The high-order bits of the structure.
        /// </summary>
        public LONG HighPart;
    }
}

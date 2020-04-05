using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains strings returned from the <see cref="IShellFolder"/> interface methods.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shtypes/ns-shtypes-strret
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct STRRET
    {
        /// <summary>
        /// A value that specifies the desired format of the string. This can be one of the following values.
        /// <see cref="STRRET_WSTR"/>, <see cref="STRRET_OFFSET"/>, <see cref="STRRET_CSTR"/>
        /// </summary>
        [FieldOffset(0)]
        public uint uType;

        /// <summary>
        /// A pointer to the string.
        /// This memory must be allocated with <see cref="CoTaskMemAlloc"/>.
        /// It is the calling application's responsibility to free this memory with <see cref="CoTaskMemFree"/> when it is no longer needed.
        /// </summary>
        [FieldOffset(4)]
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pOleStr;

        /// <summary>
        /// The offset into the item identifier list.
        /// </summary>
        [FieldOffset(4)]
        public uint uOffset;

        /// <summary>
        /// The buffer to receive the display name.
        /// </summary>
        [FieldOffset(4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cStr;
    }
}

using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="HANDLETABLE"/> structure is an array of handles,
    /// each of which identifies a graphics device interface (GDI) object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-handletable"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HANDLETABLE
    {
        /// <summary>
        /// An array of handles.
        /// </summary>
        public HGDIOBJ objectHandle;
    }
}

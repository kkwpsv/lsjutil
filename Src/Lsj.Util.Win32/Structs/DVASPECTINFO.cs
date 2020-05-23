using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that is used by the <see cref="IViewObject.Draw"/> method
    /// to optimize rendering of an inactive object by making more efficient use of the GDI.
    /// </para>
    /// <para>
    /// From: 
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DVASPECTINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public ULONG cb;

        /// <summary>
        /// A value taken from the <see cref="DVASPECTINFOFLAG"/> enumeration.
        /// </summary>
        public DVASPECTINFOFLAG dwFlags;
    }
}

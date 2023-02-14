using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an array, its element type, and its dimension.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oaidl/ns-oaidl-arraydesc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ARRAYDESC
    {
        /// <summary>
        /// The element type.
        /// </summary>
        public TYPEDESC tdescElem;

        /// <summary>
        /// The dimension count.
        /// </summary>
        public USHORT cDims;
    }
}

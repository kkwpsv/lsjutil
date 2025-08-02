using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines an item identifier.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shtypes/ns-shtypes-shitemid"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHITEMID
    {
        /// <summary>
        /// The size of identifier, in bytes, including <see cref="cb"/> itself.
        /// </summary>
        public SHORT cb;

        /// <summary>
        /// A variable-length item identifier.
        /// </summary>
        public AnySizeArray<BYTE> abID;
    }
}

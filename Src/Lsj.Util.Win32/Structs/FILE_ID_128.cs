using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines a 128-bit file identifier.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-file_id_128"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ID_128
    {
        /// <summary>
        /// A byte array containing the 128 bit identifier.
        /// </summary>
        public ByValBYTEArrayStructForSize16 Identifier;
    }
}

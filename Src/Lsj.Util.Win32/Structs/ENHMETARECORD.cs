using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ENHMETARECORD"/> structure contains data that describes a graphics device interface (GDI) function
    /// used to create part of a picture in an enhanced-format metafile.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enhmetarecord"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ENHMETARECORD
    {
        /// <summary>
        /// The record type.
        /// </summary>
        public DWORD iType;

        /// <summary>
        /// The size of the record, in bytes.
        /// </summary>
        public DWORD nSize;

        /// <summary>
        /// An array of parameters passed to the GDI function identified by the record.
        /// </summary>
        public DWORD dParm;
    }
}

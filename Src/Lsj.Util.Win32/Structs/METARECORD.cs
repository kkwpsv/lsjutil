using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="METARECORD"/> structure contains a Windows-format metafile record.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-metarecord"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct METARECORD
    {
        /// <summary>
        /// The size, in words, of the record.
        /// </summary>
        public DWORD rdSize;

        /// <summary>
        /// The function number.
        /// </summary>
        public WORD rdFunction;

        /// <summary>
        /// An array of words containing the function parameters, in reverse of the order they are passed to the function.
        /// </summary>
        public WORD rdParm;
    }
}

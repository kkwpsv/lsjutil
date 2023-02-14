using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CRYPT_INTEGER_BLOB"/> structure contains an arbitrary array of bytes.
    /// The structure definition includes aliases appropriate to the various functions that use it.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/aa381414(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CRYPT_INTEGER_BLOB
    {
        /// <summary>
        /// A <see cref="DWORD"/> variable that contains the count, in bytes, of data.
        /// </summary>
        public DWORD cbData;

        /// <summary>
        /// A pointer to the data buffer.
        /// </summary>
        public IntPtr pbData;
    }
}

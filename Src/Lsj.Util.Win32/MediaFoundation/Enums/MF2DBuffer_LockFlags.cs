using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using System;

namespace Lsj.Util.Win32.MediaFoundation.Enums
{
    /// <summary>
    /// <para>
    /// Contains flags for the <see cref="IMF2DBuffer2.Lock2DSize"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/ne-mfobjects-mf2dbuffer_lockflags"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum MF2DBuffer_LockFlags
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        MF2DBuffer_LockFlags_LockTypeMask = ((0x1 | 0x2) | 0x3),

        /// <summary>
        /// Lock the buffer for reading.
        /// </summary>
        MF2DBuffer_LockFlags_Read = 0x1,

        /// <summary>
        /// Lock the buffer for writing.
        /// </summary>
        MF2DBuffer_LockFlags_Write = 0x2,

        /// <summary>
        /// Lock the buffer for both reading and writing.
        /// </summary>
        MF2DBuffer_LockFlags_ReadWrite = 0x3,

        /// <summary>
        /// Reserved.
        /// This member forces the enumeration type to compile as a DWORD value.
        /// </summary>
        MF2DBuffer_LockFlags_ForceDWORD = 0x7fffffff
    }
}

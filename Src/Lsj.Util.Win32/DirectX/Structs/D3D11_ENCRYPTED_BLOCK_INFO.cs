using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies which bytes in a video surface are encrypted.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_encrypted_block_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_ENCRYPTED_BLOCK_INFO
    {
        /// <summary>
        /// The number of bytes that are encrypted at the start of the buffer.
        /// </summary>
        public UINT NumEncryptedBytesAtBeginning;

        /// <summary>
        /// The number of bytes that are skipped after the first <see cref="NumEncryptedBytesAtBeginning"/> bytes,
        /// and then after each block of <see cref="NumBytesInEncryptPattern"/> bytes.
        /// Skipped bytes are not encrypted.
        /// </summary>
        public UINT NumBytesInSkipPattern;

        /// <summary>
        /// The number of bytes that are encrypted after each block of skipped bytes.
        /// </summary>
        public UINT NumBytesInEncryptPattern;
    }
}

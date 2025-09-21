using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a compressed buffer for decoding.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_buffer_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_DECODER_BUFFER_DESC
    {
        /// <summary>
        /// The type of buffer, specified as a member of the <see cref="D3D11_VIDEO_DECODER_BUFFER_TYPE"/> enumeration.
        /// </summary>
        public D3D11_VIDEO_DECODER_BUFFER_TYPE BufferType;

        /// <summary>
        /// Reserved.
        /// </summary>
        public UINT BufferIndex;

        /// <summary>
        /// The offset of the relevant data from the beginning of the buffer, in bytes.
        /// This value must be zero.
        /// </summary>
        public UINT DataOffset;

        /// <summary>
        /// 
        /// </summary>
        public UINT DataSize;

        /// <summary>
        /// The macroblock address of the first macroblock in the buffer.
        /// The macroblock address is given in raster scan order.
        /// </summary>
        public UINT FirstMBaddress;

        /// <summary>
        /// The number of macroblocks of data in the buffer.
        /// This count includes skipped macroblocks.
        /// </summary>
        public UINT NumMBsInBuffer;

        /// <summary>
        /// Reserved. Set to zero.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// Reserved. Set to zero.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// Reserved. Set to zero.
        /// </summary>
        public UINT Stride;

        /// <summary>
        /// Reserved. Set to zero.
        /// </summary>
        public UINT ReservedBits;

        /// <summary>
        /// A pointer to a buffer that contains an initialization vector (IV) for encrypted data.
        /// If the decode buffer does not contain encrypted data, set this member to <see cref="NULL"/>.
        /// </summary>
        public IntPtr pIV;

        /// <summary>
        /// The size of the buffer specified in the <see cref="pIV"/> parameter.
        /// If <see cref="pIV"/> is <see cref="NULL"/>, set this member to zero.
        /// </summary>
        public UINT IVSize;

        /// <summary>
        /// If <see cref="TRUE"/>, the video surfaces are partially encrypted.
        /// </summary>
        public BOOL PartialEncryption;

        /// <summary>
        /// A <see cref="D3D11_ENCRYPTED_BLOCK_INFO"/> structure that specifies which bytes of the surface are encrypted.
        /// </summary>
        public D3D11_ENCRYPTED_BLOCK_INFO EncryptedBlockInfo;
    }
}

using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains driver-specific data for the <see cref="ID3D11VideoContext.DecoderExtension"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_extension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The exact meaning of each structure member depends on the value of <see cref="Function"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_DECODER_EXTENSION
    {
        /// <summary>
        /// The function number.
        /// This number identifies the operation to perform.
        /// Currently no function numbers are defined.
        /// </summary>
        public UINT Function;

        /// <summary>
        /// A pointer to a buffer that contains input data for the driver.
        /// </summary>
        public IntPtr pPrivateInputData;

        /// <summary>
        /// The size of the <see cref="pPrivateInputData"/> buffer, in bytes.
        /// </summary>
        public UINT PrivateInputDataSize;

        /// <summary>
        /// A pointer to a buffer that the driver can use to write output data.
        /// </summary>
        public IntPtr pPrivateOutputData;

        /// <summary>
        /// The size of the <see cref="pPrivateOutputData"/> buffer, in bytes.
        /// </summary>
        public UINT PrivateOutputDataSize;

        /// <summary>
        /// The number of elements in the <see cref="ppResourceList"/> array.
        /// If <see cref="ppResourceList"/> is <see cref="NULL"/>, set <see cref="ResourceCount"/> to zero.
        /// </summary>
        public UINT ResourceCount;

        /// <summary>
        /// The address of an array of <see cref="ID3D11Resource"/> pointers.
        /// Use this member to pass Direct3D resources to the driver.
        /// </summary>
        public P<P<ID3D11Resource>> ppResourceList;
    }
}

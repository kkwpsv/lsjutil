using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Provides access to subresource data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/D3D11/ns-d3d11-d3d11_mapped_subresource"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used in a call to <see cref="ID3D11DeviceContext.Map"/>.
    /// </para>
    /// <para>
    /// The values in these members tell you how much data you can view:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="pData"/> points to row 0 and depth slice 0.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="RowPitch"/> contains the value that the runtime adds to <see cref="pData"/> to move from row to row,
    /// where each row contains multiple pixels.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DepthPitch"/> contains the value that the runtime adds to <see cref="pData"/> to move from depth slice to depth slice,
    /// where each depth slice contains multiple rows.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// When <see cref="RowPitch"/> and <see cref="DepthPitch"/> are not appropriate for the resource type,
    /// the runtime might set their values to 0.
    /// So, don't use these values for anything other than iterating over rows and depth.
    /// Here are some examples:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// For "Buffer and Texture1D, the runtime assigns values that aren't 0 to <see cref="RowPitch"/> and <see cref="DepthPitch"/>.
    /// For example, if a Buffer contains 8 bytes, the runtime assigns values
    /// to <see cref="RowPitch"/> and <see cref="DepthPitch"/> that are greater than or equal to 8.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// For Texture2D, the runtime still assigns a value that isn't 0 to <see cref="DepthPitch"/>,
    /// assuming that the field isn't used.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// The runtime might assign values to <see cref="RowPitch"/> and <see cref="DepthPitch"/> that are larger than anticipated
    /// because there might be padding between rows and depth.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_MAPPED_SUBRESOURCE
    {
        /// <summary>
        /// <para>
        /// Pointer to the data.
        /// When <see cref="ID3D11DeviceContext.Map"/> provides the pointer, the runtime ensures that the pointer has a specific alignment,
        /// depending on the following feature levels:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// For <see cref="D3D_FEATURE_LEVEL_10_0"/> and higher, the pointer is aligned to 16 bytes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For lower than <see cref="D3D_FEATURE_LEVEL_10_0"/>, the pointer is aligned to 4 bytes.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public IntPtr pData;

        /// <summary>
        /// The row pitch, or width, or physical size (in bytes) of the data.
        /// </summary>
        public UINT RowPitch;

        /// <summary>
        /// The depth pitch, or width, or physical size (in bytes)of the data.
        /// </summary>
        public UINT DepthPitch;
    }
}

using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
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
    /// Describes the dimensions of a viewport.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_viewport"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Pass an array of these structures to the <c>pViewports</c> parameter
    /// in a call to <see cref="ID3D12GraphicsCommandList.RSSetViewports"/> to set viewports for the display.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_VIEWPORT
    {
        /// <summary>
        /// X position of the left hand side of the viewport.
        /// </summary>
        public FLOAT TopLeftX;

        /// <summary>
        /// Y position of the top of the viewport.
        /// </summary>
        public FLOAT TopLeftY;

        /// <summary>
        /// Width of the viewport.
        /// </summary>
        public FLOAT Width;

        /// <summary>
        /// Height of the viewport.
        /// </summary>
        public FLOAT Height;

        /// <summary>
        /// Minimum depth of the viewport.
        /// Ranges between 0 and 1.
        /// </summary>
        public FLOAT MinDepth;

        /// <summary>
        /// Maximum depth of the viewport.
        /// Ranges between 0 and 1.
        /// </summary>
        public FLOAT MaxDepth;
    }
}

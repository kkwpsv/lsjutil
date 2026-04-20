using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a 3D box.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_box"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the methods <see cref="ID3D12Resource.WriteToSubresource"/>,
    /// <see cref="ID3D12Resource.ReadFromSubresource"/> and <see cref="ID3D12GraphicsCommandList.CopyTextureRegion"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_BOX
    {
        /// <summary>
        /// The x position of the left hand side of the box.
        /// </summary>
        public UINT left;

        /// <summary>
        /// The y position of the top of the box.
        /// </summary>
        public UINT top;

        /// <summary>
        /// The z position of the front of the box.
        /// </summary>
        public UINT front;

        /// <summary>
        /// The x position of the right hand side of the box, plus 1.
        /// This means that <c>right - left</c> equals the width of the box.
        /// </summary>
        public UINT right;

        /// <summary>
        /// The y position of the bottom of the box, plus 1.
        /// This means that <c>bottom - top</c> equals the height of the box.
        /// </summary>
        public UINT bottom;

        /// <summary>
        /// The z position of the back of the box, plus 1. This means that <c>back - front</c> equals the depth of the box.
        /// </summary>
        public UINT back;
    }
}

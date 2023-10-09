using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the subresource from a multisampled 2D texture that is accessible to a depth-stencil view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_tex2dms_dsv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Because a multisampled 2D texture contains a single subtexture, there is nothing to specify;
    /// this unused member is included so that this structure will compile in C.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_TEX2DMS_DSV
    {
        /// <summary>
        /// Unused.
        /// </summary>
        public UINT UnusedField_NothingToDefine;
    }
}
